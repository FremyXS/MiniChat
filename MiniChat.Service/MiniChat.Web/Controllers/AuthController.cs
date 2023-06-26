using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniChat.Models.Request;
using MiniChat.Service.Authentication.Common;
using System.Security.Claims;

namespace MiniChat.Web.Controllers
{
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountCreateRequest accountCreateRequest)
        {
            try
            {
                var res = await _authenticationService.CreateAccount(accountCreateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountAuthenticateRequest accountAuthenticateRequest)
        {
            try
            {
                var res = await _authenticationService.AuthenticateAccount(accountAuthenticateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
