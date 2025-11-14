using QLCafe.Application.DTOs.Auth;
using QLCafe.Application.Interfaces;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace QLCafe.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<Account> _mockAccounts = new List<Account>
        {
            new Account { Username = "admin", Password = "123", DisplayName = "Quản Trị Viên", Role = RoleType.Admin },
            new Account { Username = "thungan1", Password = "123", DisplayName = "Thu Ngân 1", Role = RoleType.Cashier },
            new Account { Username = "thukho1", Password = "123", DisplayName = "Thủ Kho 1", Role = RoleType.InventoryManager }
        };

        public LoginResponse Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new LoginResponse { IsSuccess = false, ErrorMessage = "Vui lòng nhập đầy đủ thông tin" };

            var account = _mockAccounts.FirstOrDefault(a =>
                a.Username == request.Username && a.Password == request.Password);

            if (account != null)
            {
                return new LoginResponse
                {
                    IsSuccess = true,
                    Username = account.Username,
                    DisplayName = account.DisplayName,
                    Role = account.Role
                };
            }

            return new LoginResponse
            {
                IsSuccess = false,
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng"
            };
        }
    }
}