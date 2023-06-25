using MiniChat.Database.Entity;

namespace MiniChat.Service.User.Common
{
    public interface IGetUserByIdCommand
    {
        Task<Database.Entity.User> Invoke(long userId);
    }
}
