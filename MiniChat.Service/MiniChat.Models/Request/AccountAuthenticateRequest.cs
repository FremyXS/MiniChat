﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Request
{
    public record AccountAuthenticateRequest(
        string Login,
        string Password
    );
}
