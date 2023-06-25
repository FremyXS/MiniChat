using MiniChat.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Common
{
    public interface IGetMessageById
    {
        Task<Database.Entity.Message> Invoke(long id);
    }
}
