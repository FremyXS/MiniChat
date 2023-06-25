using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class GetUsersByIdArrayCommand: IGetUsersByIdArrayCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetUsersByIdArrayCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<List<User>> Invoke(long[] usersId)
        {
            var users = await _chatDbContext.Users
                .Where(el => usersId.Contains(el.Id)) 
                .ToListAsync();

            if (users.Count() != usersId.Length)
            {
                throw new Exception($"Not all users in the id set were found {string.Join(',', usersId)}");
            }

            return users;
        }
    }
}
