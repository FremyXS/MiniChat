using MiniChat.Models.Dto;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Service.Interface
{
    public interface IChatRoomService
    {
        Task<ICollection<ChatRoomDto>> GetChatRoomsByUserId(long userId);
        Task<ChatRoomDto> GetChatRoomById(long id);
        Task<int> CreateChatRoom(ChatRoomCreateRequest chatRoomCreateRequest);
        Task<int> UpdateChatRoom(long id, ChatRoomUpdateRequest chatRoomUpdateRequest);
        Task<int> DeleteChatRoom(long id);
    }
}
