
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace sandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlowController : Controller
    {
        public async Task<IActionResult> Index(string name)
        {

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://httpbin.org/get?name=world");
            string responseBody = await response.Content.ReadAsStringAsync();

            // todo error handling/wrapping
            response.EnsureSuccessStatusCode();

            return Content(responseBody, "application/json");

        }
    }
}
