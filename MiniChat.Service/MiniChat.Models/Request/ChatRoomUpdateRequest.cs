using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Request
{
    public class ChatRoomUpdateRequest
    {
        public string Title { get; set; }
        public string? Photo { get; set; }
        public long[] UsersId { get; set; }
    }
}
