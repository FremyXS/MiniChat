using MiniChat.Models.Dto;

namespace MiniChat.Service.Message.Common
{
    public interface IGetMessagesByChatIdCommand
    {
        Task<List<MessageDto>> Invoke(long chatId);
    }
}
