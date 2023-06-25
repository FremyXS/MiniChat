using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.User.Common;

namespace MiniChat.Service.User.Commands
{
    public class GetUserByIdCommand : IGetUserByIdCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetUserByIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<Database.Entity.User> Invoke(long userId)
        {
            var user = await _chatDbContext.Users
                .Include(el => el.ChatRooms)
                .Include(el => el.Messages)
                .FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            return user;
        }
    }
}
