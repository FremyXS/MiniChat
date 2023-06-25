using Mapster;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;
using MiniChat.Models.Request;

namespace MiniChat.Models.Mappers
{
    public static class MessageMapper
    {
        static MessageMapper()
        {
            TypeAdapterConfig<Message, MessageDto>
                .NewConfig()
                .Map(x => x.UserName, src => src.User.Name);
        }
        public static Message ToModel(this MessageCreateRequest message)
        {
            return message.Adapt<Message>();
        }

        public static MessageDto ToDto(this Message message)
        {
            return message.Adapt<MessageDto>();
        }
    }
}
