using MiniChat.Database.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class ChatRoom: EntityBase
    {
        public string Title { get; set; }
        public string? Photo { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message>? Messages { get; set; }

    }
}
