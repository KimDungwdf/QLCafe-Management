using QLCafe.Application.DTOs.Auth;

namespace QLCafe.Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}