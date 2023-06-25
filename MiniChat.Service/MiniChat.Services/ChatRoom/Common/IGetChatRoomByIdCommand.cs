namespace MiniChat.Service.ChatRoom.Common
{
    public interface IGetChatRoomByIdCommand
    {
        Task<Database.Entity.ChatRoom> Invoke(long id);
    }
}
