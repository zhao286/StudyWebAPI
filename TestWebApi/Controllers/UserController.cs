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
    public class UserController : Controller
    {
        private readonly IUserService _userService = null;
        
        //comment
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        [Route("info")]
        public IActionResult Info([FromQuery]int id)
        {
            var user = _userService.GetByID(id);
            return new JsonResult(user);
        }

        [HttpPost()]
        [Route("login")]
        public IActionResult Login(User user)
        {
            var result = _userService.Login(user);
            return new JsonResult(result);
        }

        [Route("list")]
        [HttpPost()]
        public IActionResult List()
        {
            var result = _userService.List();
            return new JsonResult(result);
        }
    }
}
