using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class GetUserByIdCommand: IGetUserByIdCommand
    {
        private readonly ChatDbContext _chatDbContext;
        
        public GetUserByIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<Database.Entity.User> Invoke(long userId)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            return user;
        }
    }
}
