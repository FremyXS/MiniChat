using Microsoft.AspNetCore.Mvc;
using MiniChat.Models.Request;
using MiniChat.Service.Message.Common;

namespace MiniChat.Web.Controllers
{
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("chat/{chatId:long}")]
        public async Task<IActionResult> GetMessagesByChatId([FromRoute] long chatId)
        {
            try
            {
                var res = await _messageService.GetMessagesByChatId(chatId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] MessageCreateRequest messageCreateRequest)
        {
            try
            {
                var res = await _messageService.CreateMessage(messageCreateRequest);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateMessage([FromRoute] long id, [FromBody] MessageUpdateRequest messageUpdateRequest)
        {
            try
            {
                var res = await _messageService.UpdateMessage(id, messageUpdateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] long id)
        {
            try
            {
                var res = await _messageService.DeleteMessage(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
