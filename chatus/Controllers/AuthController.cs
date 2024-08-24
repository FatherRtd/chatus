using Microsoft.AspNetCore.Mvc;

namespace chatus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Register()
        {
            return Ok();
        }
    }
}
