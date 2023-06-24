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

        public UpdateUserCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(long userId, UserUpdateRequest userUpdateRequest)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            user.Name = userUpdateRequest.Name;
            user.Photo = userUpdateRequest.Photo;

            _chatDbContext.Update(user);
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
