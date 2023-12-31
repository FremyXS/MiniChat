﻿using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Service.ChatRoom.Common;
using MiniChat.Service.Message.Common;

namespace MiniChat.Service.Message.Commands
{
    public class GetMessagesByChatIdCommand : IGetMessagesByChatIdCommand
    {
        private readonly IGetChatRoomByIdCommand _getChatRoomByIdCommand;

        public GetMessagesByChatIdCommand(IGetChatRoomByIdCommand getChatRoomByIdCommand)
        {
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
        }
        public async Task<List<MessageDto>> Invoke(long chatId)
        {
            var chat = await _getChatRoomByIdCommand.Invoke(chatId);

            var res = chat.Messages.Select(el => el.ToDto()).ToList();

            return res;
        }
    }
}
