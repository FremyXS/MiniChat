using MiniChat.Models.Request;

namespace MiniChat.Service.Authentication.Common
{
    public interface IAuthenticateAccountCommand
    {
        Task<string> Invoke(AccountAuthenticateRequest accountAuthenticateRequest);
    }
}
