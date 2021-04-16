using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Text.RegularExpressions;

using NiL.JS.BaseLibrary;
using NiL.JS.Core;
using NiL.JS.Extensions;

namespace worker.Controllers
{
    [ApiController]
    public class worker : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<worker> _logger;

        public worker(ILogger<worker> logger, IWebHostEnvironment webHostEnvironment)
        {
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
";
            var context = new Context();

            context
                .DefineVariable("fetch")
                .Assign(JSValue.Marshal(new Func<string, Task<dynamic>>(FetchAsync)));

            context.Eval(wrapped);



            // Act
            var resultJSON = await context.GetVariable("wrapped")
                .As<Function>()
                .Call(new Arguments { SimpleJson.SimpleJson.SerializeObject(request) })
                .As<Promise>()
                .Task;

            dynamic result = SimpleJson.SimpleJson.DeserializeObject((string)resultJSON.Value);

            return result;

        }

        private async Task<dynamic> FetchAsync(string jsRequest)
        {
            // await Task.Delay(10);
            var hello = new { hello = jsRequest };
            return hello;
        }

    }
}
