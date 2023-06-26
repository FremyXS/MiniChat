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
    public static class AccountMapper
    {
        static AccountMapper()
        {
            TypeAdapterConfig<AccountCreateRequest, User>
                .NewConfig()
                .Map(x => x.Name, src => src.UserName)
                .Map(x => x.Photo, src => src.UserPhoto);
        }
        public static Account ToModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Account>();
        }
        public static User ToUserModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<User>();
        }

    }
}
