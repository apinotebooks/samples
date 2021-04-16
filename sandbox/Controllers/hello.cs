using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NiL.JS.BaseLibrary;
using NiL.JS.Core;
using NiL.JS.Extensions;

namespace worker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class hello : ControllerBase
    {
        private readonly ILogger<hello> _logger;

        public hello(ILogger<hello> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Arrange
            var request = "world";

            var script = $@"
async function script() {{
    async function demo() {{
        let request = '{request}';
        let response = await fetch(request);        
        return response;
    }}
    let result = await demo();    
    return result;
}}
";
            var context = new Context();

            context
                .DefineVariable("fetch")
                .Assign(JSValue.Marshal(new Func<string, Task<dynamic>>(FetchAsync)));

            context.Eval(script);

            // Act
            var result = await context.GetVariable("script")
                .As<Function>()
                .Call(new Arguments())
                .As<Promise>()
                .Task;

            return new JsonResult(result.Value);

        }

        private async Task<dynamic> FetchAsync(string jsRequest)
        {
            // await Task.Delay(10);
            //var hello = new { hello = jsRequest };
            dynamic response = new SimpleJson.JsonObject();
            response.hello = jsRequest;
            return response;
        }
                     
    }
}
