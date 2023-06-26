using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniChat.Models.Request;
using MiniChat.Service.ChatRoom.Common;

namespace MiniChat.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatRoomController: ControllerBase
    {
        private readonly IChatRoomService _chatRoomService;
        public ChatRoomController(IChatRoomService chatRoomService) 
        {
            _chatRoomService = chatRoomService;
        }

        [HttpGet("user/{userId:long}")]
        public async Task<IActionResult> GetChatRoomsByUserId([FromRoute] long userId)
        {
            try
            {
                var res = await _chatRoomService.GetChatRoomsByUserId(userId);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetChatRoomById([FromRoute] long id)
        {
            try
            {
                var res = await _chatRoomService.GetChatRoomById(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatRoom([FromBody] ChatRoomCreateRequest chatRoomCreateRequest)
        {
            try
            {
                var res = await _chatRoomService.CreateChatRoom(chatRoomCreateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateChatRoom([FromRoute] long id, [FromBody] ChatRoomUpdateRequest chatRoomUpdateRequest)
        {
            try
            {
                var res = await _chatRoomService.UpdateChatRoom(id, chatRoomUpdateRequest);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteChatRoom([FromRoute] long id)
        {
            try
            {
                var res = await _chatRoomService.DeleteChatRoom(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
