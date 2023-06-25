using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MiniChat.Service.Commands
{
    public class CreateChatRoomCommand: ICreateChatRoomCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetUsersByIdArrayCommand _getUsersByIdArrayCommand;
        public CreateChatRoomCommand(
            ChatDbContext chatDbContext,
            IGetUsersByIdArrayCommand getUsersByIdArrayCommand) 
        {
            _chatDbContext = chatDbContext;
            _getUsersByIdArrayCommand = getUsersByIdArrayCommand;
        }
        public async Task<int> Invoke(ChatRoomCreateRequest chatRoomCreateRequest)
        {
            var findUsers = await _getUsersByIdArrayCommand.Invoke(chatRoomCreateRequest.UsersId);

            var chatRoom = chatRoomCreateRequest.ToModel();
            chatRoom.Users = findUsers;
            chatRoom = chatRoom.SetCreateTime();

            await _chatDbContext.ChatRooms.AddAsync(chatRoom);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
            
        }
    }
}
