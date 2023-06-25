using FluentValidation;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Models.Validators;
using MiniChat.Service.Commands.Interface;
using MiniChat.Services.Service.Interface;

namespace MiniChat.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IGetUsersCommand _getUsersCommand;
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IGetUserByIdCommand _getUserByIdCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly UserCreateRequestValidator _userCreateRequestValidator;
        private readonly UserUpdateRequestValidator _userUpdateRequestValidator;
        public UserService(
            IGetUsersCommand getUsersCommand,
            ICreateUserCommand createUserCommand,
            IDeleteUserCommand deleteUserCommand,
            IGetUserByIdCommand getUserByIdCommand,
            IUpdateUserCommand updateUserCommand,
            UserCreateRequestValidator userCreateRequestValidator,
            UserUpdateRequestValidator userUpdateRequestValidator) 
        { 
            _getUsersCommand = getUsersCommand;
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getUserByIdCommand = getUserByIdCommand;
            _updateUserCommand = updateUserCommand;
            _userCreateRequestValidator = userCreateRequestValidator;
            _userUpdateRequestValidator = userUpdateRequestValidator;
        }

        public async Task<ICollection<UserDto>> GetUsers()
        {
            return await _getUsersCommand.Invoke();
        }

        public async Task<UserDto> GetUserById(long userId)
        {
            var res = await _getUserByIdCommand.Invoke(userId);
            return res.ToDto();
        }

        public async Task<int> CreateUser(UserCreateRequest userRequest)
        {
            var validResult = await _userCreateRequestValidator.ValidateAsync(userRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _createUserCommand.Invoke(userRequest);
        }

        public async Task<int> UpdateUser(long userId, UserUpdateRequest userUpdateRequest)
        {
            var validResult = await _userUpdateRequestValidator.ValidateAsync(userUpdateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _updateUserCommand.Invoke(userId, userUpdateRequest);
        }

        public async Task<int> DeleteUser(long userId)
        {
            return await _deleteUserCommand.Invoke(userId);
        }
    }
}
