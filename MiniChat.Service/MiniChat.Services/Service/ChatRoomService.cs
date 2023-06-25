using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using MiniChat.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Service
{
    public class ChatRoomService: IChatRoomService
    {
        private readonly IGetChatRoomsByUserIdCommand _getChatRoomsByUserIdCommand;
        private readonly IGetChatRoomByIdCommand _getChatRoomByIdCommand;
        private readonly ICreateChatRoomCommand _createChatRoomCommand;
        private readonly IUpdateChatRoomCommand _updateChatRoomCommand;
        private readonly IDeleteChatRoom _deleteChatRoom;
        public ChatRoomService(
            IGetChatRoomsByUserIdCommand getChatRoomsByUserIdCommand,
            IGetChatRoomByIdCommand getChatRoomByIdCommand,
            ICreateChatRoomCommand createChatRoomCommand,
            IUpdateChatRoomCommand updateChatRoomCommand,
            IDeleteChatRoom deleteChatRoom) 
        {
            _getChatRoomsByUserIdCommand = getChatRoomsByUserIdCommand;
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
            _createChatRoomCommand = createChatRoomCommand;
            _updateChatRoomCommand = updateChatRoomCommand;
            _deleteChatRoom = deleteChatRoom;
        }

        public async Task<ICollection<ChatRoomDto>> GetChatRoomsByUserId(long userId)
        {
            return await _getChatRoomsByUserIdCommand.Invoke(userId);
        }
        public async Task<ChatRoomDto> GetChatRoomById(long id)
        {
            return await _getChatRoomByIdCommand.Invoke(id);
        }
        public async Task<int> CreateChatRoom(ChatRoomCreateRequest chatRoomCreateRequest)
        {
            return await _createChatRoomCommand.Invoke(chatRoomCreateRequest);
        }
        public async Task<int> UpdateChatRoom(long id, ChatRoomUpdateRequest chatRoomUpdateRequest)
        {
            return await _updateChatRoomCommand.Invoke(id, chatRoomUpdateRequest);
        }
        public async Task<int> DeleteChatRoom(long id)
        {
            return await _deleteChatRoom.Invoke(id);
        }
    }
}
