using Betb2bTestApp.Services;
using Betb2bTestAppModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Betb2bTestApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IUserService _userService;

        public PublicController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Produces("text/html")]
        public IActionResult UserInfo([FromQuery] GetUserRequest request)
        {
            var result = _userService.Get(request);
            return Ok(result != null?$"Id: {result.Id} Name: {result.Name} Status: {result.Status}":$"User with id {request.Id} wasn't found");
        }
    }
}