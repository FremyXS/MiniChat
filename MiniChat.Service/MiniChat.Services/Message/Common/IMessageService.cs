using MiniChat.Models.Dto;
using MiniChat.Models.Request;

namespace MiniChat.Service.Message.Common
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessagesByChatId(long chatId);
        Task<int> CreateMessage(MessageCreateRequest messageCreateRequest);
        Task<int> UpdateMessage(long id, MessageUpdateRequest messageUpdateRequest);
        Task<int> DeleteMessage(long id);
    }
}
