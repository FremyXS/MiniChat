using MiniChat.Models.Request;

namespace MiniChat.Service.Commands.Interface
{
    public interface ICreateChatRoomCommand
    {
        Task<int> Invoke(ChatRoomCreateRequest chatRoomCreateRequest);
    }
}
