using Microsoft.AspNetCore.Mvc;

namespace MiniChat.Web.Controllers
{
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpGet("chat/{chatId:long}")]
        public async Task<IActionResult> GetMessagesByChatId([FromRoute] long chatId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            return Ok();
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateMessage([FromRoute] long id)
        {
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] long id)
        {
            return Ok();
        }
    }
}
