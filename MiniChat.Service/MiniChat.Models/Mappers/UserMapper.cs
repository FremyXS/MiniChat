using Mapster;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;
using MiniChat.Models.Request;

namespace MiniChat.Models.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return user.Adapt<UserDto>();
        }

        public static User ToModel(this UserCreateRequest user)
        {
            return user.Adapt<User>();
        }
    }
}
