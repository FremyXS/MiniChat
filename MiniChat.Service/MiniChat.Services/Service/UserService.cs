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
        private readonly IDeleteUserCommand _deleteUserCommand;
        public UserService(
            IGetUsersCommand getUsersCommand,
            ICreateUserCommand createUserCommand,
            IDeleteUserCommand deleteUserCommand) 
        { 
            _getUsersCommand = getUsersCommand;
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _getUsersCommand.Invoke();
        }

        public async Task<int> CreateUser(UserRequest userRequest)
        {
            return await _createUserCommand.Invoke(userRequest);
        }

        public async Task<int> DeleteUser(long userId)
        {
            return await _deleteUserCommand.Invoke(userId);
        }
    }
}
