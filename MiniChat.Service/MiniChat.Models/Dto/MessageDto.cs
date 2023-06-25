﻿using MiniChat.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Dto
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsRedaction { get; set; }
        public DateTime CreateDate { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}
