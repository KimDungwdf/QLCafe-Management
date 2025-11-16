using QLCafe.Application.DTOs.Auth;
using QLCafe.Application.Interfaces;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(string connectionString)
        {
            _authRepository = new AuthRepository(connectionString);
        }

        public LoginResponse Login(LoginRequest request)
        {
            // Validation cơ bản
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Vui lòng nhập đầy đủ thông tin"
                };
            }

            var account = _authRepository.Authenticate(request.Username, request.Password);

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
                ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu"
            };
        }
    }
}