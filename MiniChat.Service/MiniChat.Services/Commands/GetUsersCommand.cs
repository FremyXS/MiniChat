using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Service.Commands.Interface;

namespace MiniChat.Service.Commands
{
    public class GetUsersCommand: IGetUsersCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetUsersCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<ICollection<UserDto>> Invoke()
        {
            var users = await _chatDbContext.Users.Select(el => el.ToDto())
                .ToListAsync();
            return users;
        }
    }
}
