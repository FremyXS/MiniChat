using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Common
{
    public interface IDeleteMessageCommand
    {
        Task<int> Invoke(long id);
    }
}
