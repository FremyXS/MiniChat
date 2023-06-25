using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Dto
{
    public record class ChatRoomDto(
        long Id,
        string Title,
        string? Photo,
        DateTime CreateDate
    );
}
