using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Request;
using MiniChat.Service.Authentication.Common;

namespace MiniChat.Service.Authentication.Commands
{
    public class AuthenticateAccountCommand: IAuthenticateAccountCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IVerifyPasswordHashCommand _verifyPasswordHashCommand;
        private readonly ICreateJwtTokenCommand _createJwtTokenCommand;

        public AuthenticateAccountCommand(
            ChatDbContext chatDbContext,
            IVerifyPasswordHashCommand verifyPasswordHashCommand,
            ICreateJwtTokenCommand createJwtTokenCommand)
        {
            _chatDbContext = chatDbContext;
            _verifyPasswordHashCommand = verifyPasswordHashCommand;
            _createJwtTokenCommand = createJwtTokenCommand;
        }

        public async Task<string> Invoke(AccountAuthenticateRequest accountAuthenticateRequest)
        {
            var findAccount = await _chatDbContext.Accounts
                .FirstOrDefaultAsync(el => el.Login == accountAuthenticateRequest.Login);

            if (findAccount == null)
            {
                throw new Exception($"Account with this login: {accountAuthenticateRequest.Login} was not found");
            }

            var verifyPassword = _verifyPasswordHashCommand.Invoke(
                accountAuthenticateRequest.Password,
                findAccount.PasswordHash,
                findAccount.PasswordSalt
            );

            if (!verifyPassword)
            {
                throw new Exception("Password Incorrect");
            }

            var token = _createJwtTokenCommand.Invoke(findAccount.Login);

            return token;
        }
    }
}
