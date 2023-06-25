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
        private readonly IGetUsersByIdArrayCommand _getUsersByIdArrayCommand;
        private readonly IGetChatRoomByIdCommand _getChatRoomByIdCommand;

        public UpdateChatRoomCommand(
            ChatDbContext chatDbContext,
            IGetUsersByIdArrayCommand getUsersByIdArrayCommand,
            IGetChatRoomByIdCommand getChatRoomByIdCommand)
        {
            _chatDbContext = chatDbContext;
            _getUsersByIdArrayCommand = getUsersByIdArrayCommand;
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
        }

        public async Task<int> Invoke(long id, ChatRoomUpdateRequest chatRoomUpdateRequest)
        {
            var chat = await _getChatRoomByIdCommand.Invoke(id);

            var findUsers = await _getUsersByIdArrayCommand.Invoke(chatRoomUpdateRequest.UsersId);

            chat.Title = chatRoomUpdateRequest.Title;
            chat.Photo = chatRoomUpdateRequest.Photo;
            chat.Users = findUsers;

            _chatDbContext.Update(chat);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
