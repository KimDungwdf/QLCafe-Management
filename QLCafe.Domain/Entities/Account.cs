using QLCafe.Domain.Enums;

namespace QLCafe.Domain.Entities
{
    public class Account
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public RoleType Role { get; set; }
        public string Password { get; set; } // Tạm plain text
    }
}