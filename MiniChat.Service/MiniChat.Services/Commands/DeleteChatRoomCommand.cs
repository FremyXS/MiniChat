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
        private readonly IGetChatRoomByIdCommand _getChatRoomByIdCommand;

        public DeleteChatRoomCommand(
            ChatDbContext chatDbContext,
            IGetChatRoomByIdCommand getChatRoomByIdCommand)
        {
            _chatDbContext = chatDbContext;
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
        }

        public async Task<int> Invoke(long id)
        {
            var chat = await _getChatRoomByIdCommand.Invoke(id);

            chat.SetDeleteDate();

            _chatDbContext.Update(chat);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
