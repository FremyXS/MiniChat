using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.ChatRoom.Common
{
    public interface IUpdateChatRoomCommand
    {
        Task<int> Invoke(long id, ChatRoomUpdateRequest chatRoomUpdateRequest);
    }
}
