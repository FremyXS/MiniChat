using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class UpdateUserCommand: IUpdateUserCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetUserByIdCommand _getUserByIdCommand;

        public UpdateUserCommand(
            ChatDbContext chatDbContext, 
            IGetUserByIdCommand getUserByIdCommand)
        {
            _chatDbContext = chatDbContext;
            _getUserByIdCommand = getUserByIdCommand;
        }

        public async Task<int> Invoke(long userId, UserUpdateRequest userUpdateRequest)
        {
            var user = await _getUserByIdCommand.Invoke(userId);

            user.Name = userUpdateRequest.Name;
            user.Photo = userUpdateRequest.Photo;

            _chatDbContext.Update(user);
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
