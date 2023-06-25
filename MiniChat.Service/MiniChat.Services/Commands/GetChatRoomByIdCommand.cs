using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class GetChatRoomByIdCommand: IGetChatRoomByIdCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetChatRoomByIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<ChatRoom> Invoke(long id)
        {
            var chat = await _chatDbContext.ChatRooms
                .Include(el => el.Users)
                .Include(el => el.Messages)
                .FirstOrDefaultAsync(el => el.Id == id);

            if (chat == null)
            {
                throw new Exception($"Chat room not found with id: {id}");
            }

            return chat;
        }
    }
}
