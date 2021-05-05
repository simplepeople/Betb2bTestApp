using Betb2bTestApp.Services;
using Betb2bTestAppModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Betb2bTestApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Consumes("application/xml")]
        [Produces("application/xml")]
        [Route("CreateUser")]
        public IActionResult Create(CreateUserRequest request)
        {
            var result = _userService.Create(request);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("RemoveUser")]
        public IActionResult Remove(RemoveUserRequest request)
        {
            var result = _userService.Remove(request);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json")]
        [Route("SetStatus")]
        public IActionResult SetStatus([FromForm] SetStatusRequest request)
        {
            var result = _userService.SetStatus(request);
            return Ok(result);
        }
    }
}
