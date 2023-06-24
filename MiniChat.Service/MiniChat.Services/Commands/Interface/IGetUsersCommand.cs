using MiniChat.Database.Entity;
using MiniChat.Models.Dto;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetUsersCommand
    {
        Task<ICollection<UserDto>> Invoke();
    }
}
