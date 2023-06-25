using MiniChat.Models.Request;

namespace MiniChat.Service.Commands.Interface
{
    public interface ICreateMessageCommand
    {
        Task<int> Invoke(MessageCreateRequest messageCreateRequest);
    }
}
