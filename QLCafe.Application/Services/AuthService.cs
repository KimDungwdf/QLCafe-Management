using QLCafe.Application.DTOs.Auth;
using QLCafe.Application.Interfaces;
using QLCafe.Domain.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLCafe.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _connectionString;

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResponse Login(LoginRequest request)
        {
            // 1. Validation đầu vào
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Vui lòng nhập đầy đủ thông tin"
                };
            }

            // 2. Kết nối Database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_Login", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tenDangNhap", request.Username);
                    cmd.Parameters.AddWithValue("@matKhau", request.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // --- ĐĂNG NHẬP THÀNH CÔNG ---
                            string displayName = reader["TenHienThi"].ToString();
                            int roleId = Convert.ToInt32(reader["IDVaiTro"]);

                            return new LoginResponse
                            {
                                IsSuccess = true,
                                Username = request.Username,
                                DisplayName = displayName,
                                Role = MapRole(roleId) // Gọi hàm chuyển đổi ID -> Enum
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Lỗi hệ thống: " + ex.Message
                    };
                }
            }

            return new LoginResponse
            {
                IsSuccess = false,
                ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu"
            };
        }

        // --- HÀM SỬA LỖI Ở ĐÂY ---
        private RoleType MapRole(int roleId)
        {
            switch (roleId)
            {
                case 1: return RoleType.Admin;            // 1 là Admin
                case 2: return RoleType.Cashier;          // 2 là Thu ngân
                case 3: return RoleType.InventoryManager; // 3 là Thủ kho

                // Thay vì trả về RoleType.None (không tồn tại), ta ép kiểu hoặc báo lỗi
                default:
                    throw new Exception($"Lỗi dữ liệu: ID vai trò {roleId} không tồn tại trong hệ thống.");
            }
        }
    }
}