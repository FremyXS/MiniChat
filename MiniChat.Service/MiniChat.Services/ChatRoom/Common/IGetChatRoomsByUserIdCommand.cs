using MiniChat.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.ChatRoom.Common
{
    public interface IGetChatRoomsByUserIdCommand
    {
        Task<ICollection<ChatRoomDto>> Invoke(long userId);
    }
}
