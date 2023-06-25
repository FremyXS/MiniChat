using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.User.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.User.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public CreateUserCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(UserCreateRequest userRequest)
        {
            var user = userRequest.ToModel();
            user.SetCreateTime();

            await _chatDbContext.AddAsync(user);
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
