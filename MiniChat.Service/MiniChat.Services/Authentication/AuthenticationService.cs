using FluentValidation;
using MiniChat.Models.Request;
using MiniChat.Models.Validators;
using MiniChat.Service.Authentication.Common;

namespace MiniChat.Service.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IAuthenticateAccountCommand _authenticateAccount;
        private readonly AccountAuthenticateRequestValidator _accountAuthenticateRequestValidator;
        private readonly AccountCreateRequestValidator _accountCreateRequestValidator;

        public AuthenticationService(
            ICreateAccountCommand createAccountCommand,
            IAuthenticateAccountCommand authenticateAccount,
            AccountCreateRequestValidator accountCreateRequestValidator,
            AccountAuthenticateRequestValidator accountAuthenticateRequestValidator)
        {
            _createAccountCommand = createAccountCommand;
            _authenticateAccount = authenticateAccount;
            _accountCreateRequestValidator = accountCreateRequestValidator;
            _accountAuthenticateRequestValidator = accountAuthenticateRequestValidator;
        }

        public async Task<int> CreateAccount(AccountCreateRequest accountCreateRequest)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(accountCreateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _createAccountCommand.Invoke(accountCreateRequest);
        }

        public async Task<string> AuthenticateAccount(AccountAuthenticateRequest accountAuthenticateRequest)
        {
            var validResult = await _accountAuthenticateRequestValidator.ValidateAsync(accountAuthenticateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _authenticateAccount.Invoke(accountAuthenticateRequest);
        }
    }
}
