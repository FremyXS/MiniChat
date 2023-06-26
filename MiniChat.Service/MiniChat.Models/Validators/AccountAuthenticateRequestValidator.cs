using FluentValidation;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Validators
{
    public class AccountAuthenticateRequestValidator: AbstractValidator<AccountAuthenticateRequest>
    {
        public AccountAuthenticateRequestValidator()
        {
            RuleFor(el => el.Login).NotEmpty().NotNull();
            RuleFor(el => el.Password).NotNull().NotEmpty();
        }
    }
}
