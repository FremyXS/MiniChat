using MiniChat.Database;
using MiniChat.Models.Request;
using MiniChat.Service.Message.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Commands
{
    public class UpdateMessageCommand : IUpdateMessageCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetMessageById _getMessageById;

        public UpdateMessageCommand(
            ChatDbContext chatDbContext,
            IGetMessageById getMessageById)
        {
            _chatDbContext = chatDbContext;
            _getMessageById = getMessageById;
        }

        public async Task<int> Invoke(long id, MessageUpdateRequest messageUpdateRequest)
        {
            var message = await _getMessageById.Invoke(id);

            message.Text = messageUpdateRequest.Text;
            message.IsRedaction = true;

            _chatDbContext.Update(message);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
