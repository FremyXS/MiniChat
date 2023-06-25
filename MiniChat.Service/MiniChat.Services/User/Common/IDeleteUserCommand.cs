using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.User.Common
{
    public interface IDeleteUserCommand
    {
        Task<int> Invoke(long userId);
    }
}
