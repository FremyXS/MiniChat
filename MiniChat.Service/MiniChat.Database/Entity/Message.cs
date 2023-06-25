using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class Message
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsRedaction { get; set; } = false;
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; } = null;
        public long ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public Message SetCreateTime()
        {
            CreateDate = DateTime.UtcNow;
            return this;
        }

        public Message SetDeleteDate()
        {
            DeleteDate = DateTime.UtcNow;
            return this;
        }
    }
}
