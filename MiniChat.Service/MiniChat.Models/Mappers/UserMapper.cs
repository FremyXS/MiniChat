using Mapster;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;

namespace MiniChat.Models.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return user.Adapt<UserDto>();
        }
    }
}
