using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NiL.JS;
using NiL.JS.BaseLibrary;
using NiL.JS.Core;
using NiL.JS.Extensions;
using sandbox.Utils;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace worker.Controllers
{
    [ApiController]
    public class worker : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public worker(IHttpClientFactory httpClientFactory, ILogger<worker> logger, IWebHostEnvironment webHostEnvironment)
        {
            _httpClientFactory = httpClientFactory;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        [Route("worker/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            // read notebook
            if (!name.EndsWith(".notebook.md")) name = name + ".notebook.md";
            string fileName = _webHostEnvironment.ContentRootPath + "\\..\\notebooks\\" + (name.Replace("..", "").Replace("\\", "-").Replace("/", ""));

            if (!System.IO.File.Exists(fileName)) return new StatusCodeResult(404);
            string content = System.IO.File.ReadAllText(fileName);

            // extract worker and connector cells
            string pattern = @"```javascript (worker|connector)[\s\S]*?\n([\s\S]*?\n)```";
            var blocks = Regex.Matches(content, pattern);

            // ensure at least one executable cell is found
            if (blocks.Count == 0) return new ObjectResult("No worker or connector cell found in notebook") { StatusCode = 400 };

            // initialize request 
            dynamic request = new SimpleJson.JsonObject();
            dynamic response = request;

            foreach (var q in Request.Query)
            {
                request[q.Key] = q.Value.ToString();
            }


            foreach (Match m in blocks)
            {
                string cellContent = m.Groups[2].Value;
                response = await Execute(cellContent, request);
                request = response;
            }

            return new JsonResult(response);
        }

        private async Task<dynamic> Execute(string script, dynamic request)
        {
            // wrap function to return result as JSON string
            var wrapped = $@"
                {script}

                async function wrapped(request, context) {{     
                    let response = await handleRequest(JSON.parse(request));    
                    return JSON.stringify(response);
                }}

                async function fetchJSON(url, options) {{
                    var str = await _fetchJSON(url, options);
                    return JSON.parse(str);
                }}
            ";

            var module = new Module(wrapped);

            module
                .Context
                .DefineVariable("_fetchJSON")
                .Assign(JSValue.Marshal(new Func<string, dynamic, Task<string>>(FetchJSONAsync)));

            module
                .Context
                .DefineVariable("sandboxImport")
                .Assign(JSValue.Marshal(new Func<string, Task<JSValue>>(SandboxImporter.Import)));

            try
            {
                module.Run();

                // Act
                var resultJSON = await module
                    .Context
                    .GetVariable("wrapped")
                    .As<Function>()
                    .Call(new Arguments { SimpleJson.SimpleJson.SerializeObject(request) })
                    .As<Promise>()
                    .Task;

                dynamic result = SimpleJson.SimpleJson.DeserializeObject((string)resultJSON.Value);

                return result;
            }
            catch (Exception e)
            {
                return new
                {
                    error = e.Message
                };
            }
        }

        // does not work with current NuGET version, requires latest dev buid
        private async Task<string> FetchJSONAsync(string url, dynamic options)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            // todo error handling/wrapping
            response.EnsureSuccessStatusCode();

            return responseBody;
        }

    }
}
