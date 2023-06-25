namespace MiniChat.Models.Request
{
    public record MessageCreateRequest(
        string Text,
        long ChatRoomId,
        long UserId
    );
}
