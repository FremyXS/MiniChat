using MiniChat.Models.Request;

namespace MiniChat.Service.ChatRoom.Common
{
    public interface ICreateChatRoomCommand
    {
        Task<int> Invoke(ChatRoomCreateRequest chatRoomCreateRequest);
    }
}
