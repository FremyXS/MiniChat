using MiniChat.Models.Request;
using MiniChat.Service.Authentication.Common;

namespace MiniChat.Service.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IAuthenticateAccountCommand _authenticateAccount;

        public AuthenticationService(
            ICreateAccountCommand createAccountCommand,
            IAuthenticateAccountCommand authenticateAccount)
        {
            _createAccountCommand = createAccountCommand;
            _authenticateAccount = authenticateAccount;
        }

        public async Task<int> CreateAccount(AccountCreateRequest accountCreateRequest)
        {
            return await _createAccountCommand.Invoke(accountCreateRequest);
        }

        public async Task<string> AuthenticateAccount(AccountAuthenticateRequest accountAuthenticateRequest)
        {
            return await _authenticateAccount.Invoke(accountAuthenticateRequest);
        }
    }
}
