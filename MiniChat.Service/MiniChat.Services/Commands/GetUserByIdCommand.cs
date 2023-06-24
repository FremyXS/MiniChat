using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Service.Commands.Interface;

namespace MiniChat.Service.Commands
{
    public class GetUserByIdCommand: IGetUserByIdCommand
    {
        private readonly ChatDbContext _chatDbContext;
        
        public GetUserByIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<UserDto> Invoke(long userId)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            return user.ToDto();
        }
    }
}
