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
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly ChatDbContext _chatDbContext;
        public DeleteUserCommand(ChatDbContext chatDbContext) 
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(long userId)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            _chatDbContext.Update(user.SetDeleteDate());
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
