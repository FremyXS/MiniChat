using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.Message.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Commands
{
    public class DeleteMessageCommand : IDeleteMessageCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetMessageById _getMessageById;

        public DeleteMessageCommand(
            ChatDbContext chatDbContext,
            IGetMessageById getMessageById)
        {
            _chatDbContext = chatDbContext;
            _getMessageById = getMessageById;
        }

        public async Task<int> Invoke(long id)
        {
            var message = await _getMessageById.Invoke(id);

            message.SetDeleteDate();
            _chatDbContext.Update(message);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
