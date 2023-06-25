using MiniChat.Database.Entity;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetChatRoomByIdCommand
    {
        Task<ChatRoom> Invoke(long id);
    }
}
