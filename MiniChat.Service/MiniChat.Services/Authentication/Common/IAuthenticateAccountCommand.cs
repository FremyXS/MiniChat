using MiniChat.Models.Request;

namespace MiniChat.Service.Authentication.Common
{
    public interface IAuthenticateAccount
    {
        Task<string> Invoke(AccountAuthenticateRequest accountAuthenticateRequest);
    }
}
