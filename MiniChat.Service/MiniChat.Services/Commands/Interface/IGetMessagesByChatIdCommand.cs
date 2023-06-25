using MiniChat.Models.Dto;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetMessagesByChatIdCommand
    {
        Task<List<MessageDto>> Invoke(long chatId);
    }
}
