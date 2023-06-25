using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.User.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.User.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetUserByIdCommand _getUserByIdCommand;
        public DeleteUserCommand(
            ChatDbContext chatDbContext,
            IGetUserByIdCommand getUserByIdCommand)
        {
            _chatDbContext = chatDbContext;
            _getUserByIdCommand = getUserByIdCommand;
        }

        public async Task<int> Invoke(long userId)
        {
            var user = await _getUserByIdCommand.Invoke(userId);
            user.SetDeleteDate();

            _chatDbContext.Update(user);
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
