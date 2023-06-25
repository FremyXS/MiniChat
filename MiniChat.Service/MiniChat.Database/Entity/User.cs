using MiniChat.Database.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string? Photo { get; set; }
        public ICollection<ChatRoom>? ChatRooms { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
