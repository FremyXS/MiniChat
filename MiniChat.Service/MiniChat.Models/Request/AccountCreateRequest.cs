namespace MiniChat.Models.Request
{
    public record class AccountCreateRequest(
        string Email,
        string Login,
        string Password,
        string UserName,
        string? UserPhoto
    );
}
