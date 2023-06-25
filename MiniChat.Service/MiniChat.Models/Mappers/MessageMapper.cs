using Mapster;
using MiniChat.Database.Entity;
using MiniChat.Models.Request;

namespace MiniChat.Models.Mappers
{
    public static class MessageMapper
    {
        //static MessageMapper()
        //{
        //    TypeAdapterConfig<MessageCreateRequest, Message>
        //        .NewConfig()
        //        .Map(x => x.ChatRoom)
        //}
        public static Message ToModel(this MessageCreateRequest message)
        {
            return message.Adapt<Message>();
        }
    }
}
