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
        public CreateChatRoomCommand(ChatDbContext chatDbContext) 
        {
            _chatDbContext = chatDbContext;
        }
        public async Task<int> Invoke(ChatRoomCreateRequest chatRoomCreateRequest)
        {
            var users = await _chatDbContext.Users.ToListAsync();

            var findUsers = users.Where(el => chatRoomCreateRequest.UsersId.Contains(el.Id)).ToList();

            if (findUsers.Count() != chatRoomCreateRequest.UsersId.Length) 
            {
                throw new Exception($"Not all users in the id set were found {string.Join(',', chatRoomCreateRequest.UsersId)}");
            }

            var chatRoom = chatRoomCreateRequest.ToModel();
            chatRoom.Users = findUsers;
            chatRoom = chatRoom.SetCreateTime();

            await _chatDbContext.ChatRooms.AddAsync(chatRoom);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
            
        }
    }
}
