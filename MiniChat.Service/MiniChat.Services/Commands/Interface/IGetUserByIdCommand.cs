using MiniChat.Database.Entity;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetUserByIdCommand
    {
        Task<User> Invoke(long userId);
    }
}
