using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Authentication.Common
{
    public interface ICreateJwtTokenCommand
    {
        string Invoke(string accountLogin);
    }
}
