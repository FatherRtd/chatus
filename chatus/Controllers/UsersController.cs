using chatus.API.Contracts;
using chatus.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace chatus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("ok");
        }
    }
}
