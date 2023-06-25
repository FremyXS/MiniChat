using Mapster;
using MiniChat.Database.Entity;
using MiniChat.Models.Dto;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Mappers
{
    public static class ChatRoomMapper
    {
        static ChatRoomMapper()
        {
            TypeAdapterConfig<ChatRoomCreateRequest, ChatRoom>
                .NewConfig()
                .Map(x => x.Users, src => new List<User>());
        }
        public static ChatRoom ToModel(this ChatRoomCreateRequest chatRoomCreateRequest)
        {
            return chatRoomCreateRequest.Adapt<ChatRoom>();
        }

        public static ChatRoomDto ToDto(this ChatRoom chatRoom)
        {
            return chatRoom.Adapt<ChatRoomDto>();
        }
    }
}
