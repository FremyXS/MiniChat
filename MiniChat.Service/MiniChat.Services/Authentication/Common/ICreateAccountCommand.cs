using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Authentication.Common
{
    public interface ICreateAccountCommand
    {
        Task<int> Invoke(AccountCreateRequest accountCreateRequest);
    }
}
