using QLCafe.Domain.Enums;

namespace QLCafe.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; } // PK
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } // Hoạt động / Ngừng
    }
}