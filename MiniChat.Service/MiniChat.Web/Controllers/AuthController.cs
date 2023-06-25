using Microsoft.AspNetCore.Mvc;

namespace MiniChat.Web.Controllers
{
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
