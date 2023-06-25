using MiniChat.Models.Request;

namespace MiniChat.Service.Message.Common
{
    public interface ICreateMessageCommand
    {
        Task<int> Invoke(MessageCreateRequest messageCreateRequest);
    }
}
