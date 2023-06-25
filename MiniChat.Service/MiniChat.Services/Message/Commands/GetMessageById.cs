using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Service.Message.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Message.Commands
{
    public class GetMessageById : IGetMessageById
    {
        private readonly ChatDbContext _chatDbContext;

        public GetMessageById(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<Database.Entity.Message> Invoke(long id)
        {
            var message = await _chatDbContext.Messages
                .Include(el => el.User)
                .Include(el => el.ChatRoom)
                .FirstOrDefaultAsync(el => el.Id == id);

            if (message == null)
            {
                throw new Exception($"Message is not found by id: {id}");
            }

            return message;
        }
    }
}
