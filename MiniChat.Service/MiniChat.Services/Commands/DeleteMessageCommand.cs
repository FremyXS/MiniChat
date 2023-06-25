using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class DeleteMessageCommand: IDeleteMessageCommand
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

            message = message.SetDeleteDate();
            _chatDbContext.Update(message);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
