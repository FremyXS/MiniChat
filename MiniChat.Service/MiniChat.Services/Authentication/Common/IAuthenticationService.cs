using MiniChat.Models.Request;

namespace MiniChat.Service.Authentication.Common
{
    public interface IAuthenticationService
    {
        Task<int> CreateAccount(AccountCreateRequest accountCreateRequest);
        Task<string> AuthenticateAccount(AccountAuthenticateRequest accountAuthenticateRequest);
    }
}
