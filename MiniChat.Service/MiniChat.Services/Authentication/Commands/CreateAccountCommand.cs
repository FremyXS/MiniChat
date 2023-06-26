using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.Authentication.Common;

namespace MiniChat.Service.Authentication.Commands
{
    public class CreateAccountCommand: ICreateAccountCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly ICreatePasswordHashCommand _createPasswordHashCommand;

        public CreateAccountCommand(ChatDbContext chatDbContext, ICreatePasswordHashCommand createPasswordHashCommand)
        {
            _chatDbContext = chatDbContext;
            _createPasswordHashCommand = createPasswordHashCommand;
        }

        public async Task<int> Invoke(AccountCreateRequest accountCreateRequest)
        {
            var findAccount = await _chatDbContext.Accounts
                .FirstOrDefaultAsync(el => el.Email.Contains(accountCreateRequest.Email) || el.Login.Contains(accountCreateRequest.Login));

            if (findAccount != null)
            {
                throw new ArgumentException($"This login: {accountCreateRequest.Login} or email: {accountCreateRequest.Email} is already used");
            }

            byte[] passwordHash, passwordSalt;
            _createPasswordHashCommand.Invoke(accountCreateRequest.Password, out passwordHash, out passwordSalt);

            var user = accountCreateRequest.ToUserModel();
            user.SetCreateTime();
            var userEntity = await _chatDbContext.Users.AddAsync(user);

            var account = accountCreateRequest.ToModel();
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;
            account.UserId = userEntity.Entity.Id;
            account.User = userEntity.Entity;
            account.SetCreateTime();

            var accountEntity = await _chatDbContext.Accounts.AddAsync(account);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
