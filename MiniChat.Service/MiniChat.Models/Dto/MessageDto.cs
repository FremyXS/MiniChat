namespace MiniChat.Models.Dto
{
    public record class MessageDto(
        long Id,
        string Text,
        bool IsRedaction,
        DateTime CreateDate,
        long UserId,
        string UserName
    );
}
