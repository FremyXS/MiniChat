﻿using MiniChat.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Commands.Interface
{
    public interface IGetUsersCommand
    {
        Task<ICollection<User>> Invoke();
    }
}
