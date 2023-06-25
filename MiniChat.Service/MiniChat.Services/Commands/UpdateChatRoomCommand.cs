using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands
{
    public class UpdateChatRoomCommand: IUpdateChatRoomCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public UpdateChatRoomCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<int> Invoke(long id, ChatRoomUpdateRequest chatRoomUpdateRequest)
        {
            var chat = await _chatDbContext.ChatRooms
                .Include(el => el.Users)
                .FirstOrDefaultAsync(el => el.Id == id);

            if (chat == null)
            {
                throw new Exception($"Chat room not found with id: {id}");
            }

            var users = await _chatDbContext.Users.ToListAsync();

            var findUsers = users
                .Where(el => chatRoomUpdateRequest.UsersId.Contains(el.Id))
                .ToList();

            if (findUsers.Count() != chatRoomUpdateRequest.UsersId.Length)
            {
                throw new Exception($"Not all users in the id set were found {string.Join(',', chatRoomUpdateRequest.UsersId)}");
            }

            chat.Title = chatRoomUpdateRequest.Title;
            chat.Photo = chatRoomUpdateRequest.Photo;
            chat.Users = findUsers;

            _chatDbContext.Update(chat);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
