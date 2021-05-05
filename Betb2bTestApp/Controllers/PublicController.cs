using Betb2bTestApp.Models;
using Betb2bTestApp.Services;
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
            return result != null ? Ok($"Id: {result.Id} Name: {result.Name} Status: {result.Status}") : NotFound();
        }
    }
}