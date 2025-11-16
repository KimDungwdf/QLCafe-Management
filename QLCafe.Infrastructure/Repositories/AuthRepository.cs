using QLCafe.Domain.Entities;
using QLCafe.Domain.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLCafe.Infrastructure.Repositories
{
    public class AuthRepository
    {
        private readonly string _connectionString;

        public AuthRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Account Authenticate(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("sp_Login", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@tenDangNhap", username);
                        command.Parameters.AddWithValue("@matKhau", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Account
                                {
                                    Username = reader["TenDangNhap"].ToString(),
                                    DisplayName = reader["TenHienThi"].ToString(),
                                    Role = (RoleType)Convert.ToInt32(reader["IDVaiTro"]),
                                    Password = password // GÁN PASSWORD ĐỂ DÙNG SAU NÀY
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đăng nhập: {ex.Message}");
            }
            return null;
        }

        // THÊM PHƯƠNG THỨC TẠO TÀI KHOẢN MỚI (CHO ADMIN)
        public bool CreateAccount(Account account)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(
                        "INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro) VALUES (@Username, @DisplayName, @Password, @Role)", connection))
                    {
                        command.Parameters.AddWithValue("@Username", account.Username);
                        command.Parameters.AddWithValue("@DisplayName", account.DisplayName);
                        command.Parameters.AddWithValue("@Password", account.Password); // Plain text
                        command.Parameters.AddWithValue("@Role", (int)account.Role);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo tài khoản: {ex.Message}");
            }
        }
    }
}