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
    public class EmptyController : Controller
    {
        public async Task<IActionResult> Index(string name)
        {
            return new JsonResult(new { hello = "world" });
        }
    }
}