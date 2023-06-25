namespace MiniChat.Models.Dto
{
    public record class UserDto(
        long Id,
        string Name,
        string? Photo,
        DateTime CreateDate
    );
}
