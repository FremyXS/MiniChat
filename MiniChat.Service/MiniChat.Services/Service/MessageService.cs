using MiniChat.Models.Dto;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;
using MiniChat.Service.Service.Interface;

namespace MiniChat.Service.Service
{
    public class MessageService: IMessageService
    {
        private readonly IGetMessagesByChatIdCommand _getMessagesByChatIdCommand;
        private readonly ICreateMessageCommand _createMessageCommand;
        private readonly IUpdateMessageCommand _updateMessageCommand;
        private readonly IDeleteMessageCommand _deleteMessageCommand;

        public MessageService(
            IGetMessagesByChatIdCommand getMessagesByChatIdCommand,
            ICreateMessageCommand createMessageCommand,
            IUpdateMessageCommand updateMessageCommand,
            IDeleteMessageCommand deleteMessageCommand)
        {
            _getMessagesByChatIdCommand = getMessagesByChatIdCommand;
            _createMessageCommand = createMessageCommand;
            _updateMessageCommand = updateMessageCommand;
            _deleteMessageCommand = deleteMessageCommand;
        }

        public async Task<List<MessageDto>> GetMessagesByChatId(long chatId)
        {
            return await _getMessagesByChatIdCommand.Invoke(chatId);
        }
        public async Task<int> CreateMessage(MessageCreateRequest messageCreateRequest)
        {
            return await _createMessageCommand.Invoke(messageCreateRequest);
        }
        public async Task<int> UpdateMessage(long id, MessageUpdateRequest messageUpdateRequest)
        {
            return await _updateMessageCommand.Invoke(id, messageUpdateRequest);
        }
        public async Task<int> DeleteMessage(long id)
        {
            return await _deleteMessageCommand.Invoke(id);
        }
    }
}
