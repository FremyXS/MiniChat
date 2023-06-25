using MiniChat.Database.Entity;
using MiniChat.Models.Dto;

namespace MiniChat.Service.User.Common
{
    public interface IGetUsersCommand
    {
        Task<ICollection<UserDto>> Invoke();
    }
}
