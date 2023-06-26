using FluentValidation;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Validators
{
    public class AccountCreateRequestValidator: AbstractValidator<AccountCreateRequest>
    {
        public AccountCreateRequestValidator()
        {
            RuleFor(el => el.Login).NotEmpty().NotNull();
            RuleFor(el => el.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(el => el.Password).NotNull().NotEmpty();
            RuleFor(el => el.UserName).NotNull().NotEmpty();
        }
    }
}
