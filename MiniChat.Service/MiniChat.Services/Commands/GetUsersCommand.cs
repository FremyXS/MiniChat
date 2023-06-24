using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class GetUsersCommand: IGetUsersCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetUsersCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<ICollection<User>> Invoke()
        {
            var users = await _chatDbContext.Users.ToListAsync();
            return users;
        }
    }
}
