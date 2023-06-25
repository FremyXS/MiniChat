using FluentValidation;
using MiniChat.Models.Dto;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Models.Validators;
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
        private readonly IDeleteChatRoomCommand _deleteChatRoom;
        private readonly ChatRoomCreateRequestValidator _chatRoomCreateRequestValidator;
        private readonly ChatRoomUpdateRequestValidator _chatRoomUpdateRequestValidator;
        public ChatRoomService(
            IGetChatRoomsByUserIdCommand getChatRoomsByUserIdCommand,
            IGetChatRoomByIdCommand getChatRoomByIdCommand,
            ICreateChatRoomCommand createChatRoomCommand,
            IUpdateChatRoomCommand updateChatRoomCommand,
            IDeleteChatRoomCommand deleteChatRoom,
            ChatRoomCreateRequestValidator chatRoomCreateRequestValidator,
            ChatRoomUpdateRequestValidator chatRoomUpdateRequestValidator) 
        {
            _getChatRoomsByUserIdCommand = getChatRoomsByUserIdCommand;
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
            _createChatRoomCommand = createChatRoomCommand;
            _updateChatRoomCommand = updateChatRoomCommand;
            _deleteChatRoom = deleteChatRoom;
            _chatRoomCreateRequestValidator = chatRoomCreateRequestValidator;
            _chatRoomUpdateRequestValidator = chatRoomUpdateRequestValidator;
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
            var validResult = await _chatRoomCreateRequestValidator.ValidateAsync(chatRoomCreateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _createChatRoomCommand.Invoke(chatRoomCreateRequest);
        }
        public async Task<int> UpdateChatRoom(long id, ChatRoomUpdateRequest chatRoomUpdateRequest)
        {
            var validResult = await _chatRoomUpdateRequestValidator.ValidateAsync(chatRoomUpdateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _updateChatRoomCommand.Invoke(id, chatRoomUpdateRequest);
        }
        public async Task<int> DeleteChatRoom(long id)
        {
            return await _deleteChatRoom.Invoke(id);
        }
    }
}
