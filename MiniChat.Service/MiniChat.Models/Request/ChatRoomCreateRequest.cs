namespace MiniChat.Models.Request
{
    public record ChatRoomCreateRequest(
        string Title,
        string? Photo,
        long[] UsersId
    );
}
