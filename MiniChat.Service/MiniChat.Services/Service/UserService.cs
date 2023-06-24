using MiniChat.Database.Entity;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using MiniChat.Services.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IGetUsersCommand _getUsersCommand;
        private readonly ICreateUserCommand _createUserCommand;
        public UserService(
            IGetUsersCommand getUsersCommand,
            ICreateUserCommand createUserCommand) 
        { 
            _getUsersCommand = getUsersCommand;
            _createUserCommand = createUserCommand;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _getUsersCommand.Invoke();
        }

        public async Task<int> CreateUser(UserRequest userRequest)
        {
            return await _createUserCommand.Invoke(userRequest);
        }
    }
}
