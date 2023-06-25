namespace MiniChat.Models.Request
{
    public record ChatRoomUpdateRequest(
        string Title,
        string? Photo,
        long[] UsersId
    );
}
