using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.IServices;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        private readonly IDemoService _demoService = null;
        
        //comment
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [Route("list")]
        [HttpPost()]
        public IActionResult List()
        {
            var result = _demoService.List();
            return new JsonResult(result);
        }
    }
}
