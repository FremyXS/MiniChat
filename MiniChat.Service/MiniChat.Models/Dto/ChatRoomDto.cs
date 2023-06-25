using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Dto
{
    public class ChatRoomDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Photo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
