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
    public class DeleteChatRoomCommand: IDeleteChatRoomCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public DeleteChatRoomCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(long id)
        {
            var chat = await _chatDbContext.ChatRooms
                .FirstOrDefaultAsync(el => el.Id == id);

            if (chat == null)
            {
                throw new Exception($"Chat room not found with id: {id}");
            }

            chat = chat.SetDeleteDate();

            _chatDbContext.Update(chat);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
