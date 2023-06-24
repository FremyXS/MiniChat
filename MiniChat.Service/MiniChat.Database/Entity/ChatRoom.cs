﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity
{
    public class ChatRoom
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; } = null;
        public ICollection<User> Users { get; set; }
        public ICollection<Message>? Messages { get; set; }

        public ChatRoom SetCreateTime()
        {
            CreateDate = DateTime.UtcNow;
            return this;
        }

        public ChatRoom SetDeleteDate()
        {
            DeleteDate = DateTime.UtcNow;
            return this;
        }
    }
}
