using Microsoft.AspNetCore.Mvc;
using MiniChat.Models.Request;
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
            try
            {
                var res = await _userService.GetUsers();
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetUserById([FromRoute] long id)
        {
            try
            {
                var res = await _userService.GetUserById(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest userRequest)
        {
            try
            {
                var res = await _userService.CreateUser(userRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            try
            {
                var res = await _userService.UpdateUser(id, userUpdateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            try
            {
                var res = await _userService.DeleteUser(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
