using FluentValidation;
using MiniChat.Models.Request;

namespace MiniChat.Models.Validators
{
    public class ChatRoomUpdateRequestValidator: AbstractValidator<ChatRoomUpdateRequest>
    {
        public ChatRoomUpdateRequestValidator() 
        {
            RuleFor(el => el.Title)
                .NotEmpty()
                .NotNull();
            RuleFor(el => el.UsersId)
                .NotEmpty()
                .NotNull()
                .Must(el => el.Length >= 2)
                .WithMessage("The array must contain at least two users");
        }
    }
}
