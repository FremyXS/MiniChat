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
        private readonly IGetUserByIdCommand _getUserByIdCommand;
        public GetChatRoomsByUserIdCommand(IGetUserByIdCommand getUserByIdCommand)
        {
            _getUserByIdCommand = getUserByIdCommand;
        }

        public async Task<ICollection<ChatRoomDto>> Invoke(long userId)
        {
            var user = await _getUserByIdCommand.Invoke(userId);

            var res = user.ChatRooms.Select(el => el.ToDto()).ToList();

            return res;
        }
    }
}
