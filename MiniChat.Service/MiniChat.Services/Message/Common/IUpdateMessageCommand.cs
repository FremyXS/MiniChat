using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Common
{
    public interface IUpdateMessageCommand
    {
        Task<int> Invoke(long id, MessageUpdateRequest messageUpdateRequest);
    }
}
