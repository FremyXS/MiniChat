using Microsoft.AspNetCore.Mvc;
using MiniChat.Models.Request;
using MiniChat.Services.Service;
using MiniChat.Services.Service.Interface;

namespace MiniChat.Web.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; 
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var res = await _userService.GetUsers();
            return Ok(res);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetUserById([FromRoute] long id)
        {
            var res = await _userService.GetUserById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            var res = await _userService.CreateUser(userRequest);
            return Ok(res);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            var res = await _userService.DeleteUser(id);
            return Ok(res);
        }
    }
}
