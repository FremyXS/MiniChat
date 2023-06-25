using MiniChat.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Request
{
    public class MessageCreateRequest
    {
        public string Text { get; set; }
        public long ChatRoomId { get; set; }
        public long UserId { get; set; }
    }
}
