using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; } = null;
        public ICollection<ChatRoom>? ChatRooms { get; set; }
        public ICollection<Message>? Messages { get; set; }

        public void SetCreateTime()
        {
            CreateDate = DateTime.UtcNow;
        }
    }
}
