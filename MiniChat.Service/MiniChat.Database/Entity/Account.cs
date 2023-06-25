using MiniChat.Database.Entity.Common;

namespace MiniChat.Database.Entity
{
    public class Account: EntityBase
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
