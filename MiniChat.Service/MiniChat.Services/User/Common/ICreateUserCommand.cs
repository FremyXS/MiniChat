using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.User.Common
{
    public interface ICreateUserCommand
    {
        Task<int> Invoke(UserCreateRequest userRequest);
    }
}
