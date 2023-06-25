using MiniChat.Database.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class Message : EntityBase
    {
        public string Text { get; set; }
        public bool IsRedaction { get; set; } = false;
        public long ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
