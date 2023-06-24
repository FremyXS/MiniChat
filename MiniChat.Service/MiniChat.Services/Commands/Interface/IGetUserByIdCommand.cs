using MiniChat.Models.Dto;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetUserByIdCommand
    {
        Task<UserDto> Invoke(long userId);
    }
}
