using MiniChat.Models.Dto;
using MiniChat.Models.Request;

namespace MiniChat.Service.User.Common
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetUsers();
        Task<UserDto> GetUserById(long userId);
        Task<int> CreateUser(UserCreateRequest userRequest);
        Task<int> UpdateUser(long userId, UserUpdateRequest userUpdateRequest);
        Task<int> DeleteUser(long userId);
    }
}
