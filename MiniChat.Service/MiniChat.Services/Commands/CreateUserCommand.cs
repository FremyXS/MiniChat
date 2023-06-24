using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class CreateUserCommand: ICreateUserCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public CreateUserCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(UserCreateRequest userRequest)
        {
            var user = userRequest.ToModel();
            user = user.SetCreateTime();

            await _chatDbContext.AddAsync(user);
            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
