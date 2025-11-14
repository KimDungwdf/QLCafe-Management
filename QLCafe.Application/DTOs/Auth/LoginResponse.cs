using QLCafe.Domain.Enums;

namespace QLCafe.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public RoleType Role { get; set; }
        public string ErrorMessage { get; set; }
    }
}