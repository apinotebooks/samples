
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
    public class GetController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public GetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string name)
        {

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync("https://httpbin.org/get?name=world");
            string responseBody = await response.Content.ReadAsStringAsync();

            // todo error handling/wrapping
            response.EnsureSuccessStatusCode();

            return Content(responseBody, "application/json");

        }
    }
}
