using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
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
    public class GetChatRoomsByUserIdCommand: IGetChatRoomsByUserIdCommand
    {
        private readonly ChatDbContext _chatDbContext;
        public GetChatRoomsByUserIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<ICollection<ChatRoomDto>> Invoke(long userId)
        {
            var user = await _chatDbContext.Users
                .Include(el => el.ChatRooms)
                .FirstOrDefaultAsync(el => el.Id == userId);

            if (user == null)
            {
                throw new Exception($"User is not found by id: {userId}");
            }

            var res = user.ChatRooms.Select(el => el.ToDto()).ToList();

            return res;
        }
    }
}
