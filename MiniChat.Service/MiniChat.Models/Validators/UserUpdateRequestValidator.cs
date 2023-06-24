using FluentValidation;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Validators
{
    public class UserUpdateRequestValidator: AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator() 
        {
            RuleFor(el => el.Name).NotEmpty().NotNull();
        }
    }
}
