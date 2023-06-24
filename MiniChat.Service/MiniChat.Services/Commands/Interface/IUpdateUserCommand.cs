using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands.Interface
{
    public interface IUpdateUserCommand
    {
        Task<int> Invoke(long userId, UserUpdateRequest userUpdateRequest);
    }
}
