﻿using MiniChat.Database.Entity;
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
        private readonly IGetUserByIdCommand _getUserByIdCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        public UserService(
            IGetUsersCommand getUsersCommand,
            ICreateUserCommand createUserCommand,
            IDeleteUserCommand deleteUserCommand,
            IGetUserByIdCommand getUserByIdCommand,
            IUpdateUserCommand updateUserCommand) 
        { 
            _getUsersCommand = getUsersCommand;
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getUserByIdCommand = getUserByIdCommand;
            _updateUserCommand = updateUserCommand;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _getUsersCommand.Invoke();
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _getUserByIdCommand.Invoke(userId);
        }

        public async Task<int> CreateUser(UserCreateRequest userRequest)
        {
            return await _createUserCommand.Invoke(userRequest);
        }

        public async Task<int> UpdateUser(long userId, UserUpdateRequest userUpdateRequest)
        {
            return await _updateUserCommand.Invoke(userId, userUpdateRequest);
        }

        public async Task<int> DeleteUser(long userId)
        {
            return await _deleteUserCommand.Invoke(userId);
        }
    }
}
