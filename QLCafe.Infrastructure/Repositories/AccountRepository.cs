using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Enums;

namespace QLCafe.Infrastructure.Repositories
{
    public class AccountRepository
    {
        private readonly string _connectionString;
        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Account> GetAccounts()
        {
            var list = new List<Account>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT TenDangNhap, TenHienThi, MatKhau, IDVaiTro FROM TaiKhoan", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Account
                        {
                            Id = 0,
                            Username = reader["TenDangNhap"].ToString(),
                            DisplayName = reader["TenHienThi"].ToString(),
                            Password = reader["MatKhau"].ToString(),
                            Role = (RoleType)Convert.ToInt32(reader["IDVaiTro"]),
                            Phone = string.Empty,
                            Status = "Hoạt động"
                        });
                    }
                }
            }
            return list;
        }

        public Account GetByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT TenDangNhap, TenHienThi, MatKhau, IDVaiTro FROM TaiKhoan WHERE TenDangNhap=@un", connection))
                {
                    cmd.Parameters.AddWithValue("@un", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account
                            {
                                Id = 0,
                                Username = reader["TenDangNhap"].ToString(),
                                DisplayName = reader["TenHienThi"].ToString(),
                                Password = reader["MatKhau"].ToString(),
                                Role = (RoleType)Convert.ToInt32(reader["IDVaiTro"]),
                                Phone = string.Empty,
                                Status = "Hoạt động"
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Create(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                // Sử dụng stored procedure sp_Admin_InsertAccount
                using (var cmd = new SqlCommand("sp_Admin_InsertAccount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", account.Username);
                    cmd.Parameters.AddWithValue("@TenHienThi", account.DisplayName);
                    cmd.Parameters.AddWithValue("@MatKhau", account.Password); // Plain text, SP sẽ hash SHA2_256
                    cmd.Parameters.AddWithValue("@IDVaiTro", (int)account.Role);
                    
                    // Thêm return value parameter
                    var returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;
                    
                    cmd.ExecuteNonQuery();
                    
                    int result = (int)returnParam.Value;
                    
                    // Xử lý mã lỗi
                    switch (result)
                    {
                        case 0:
                            throw new Exception("Tên đăng nhập đã tồn tại!");
                        case -1:
                            throw new Exception("Vai trò không hợp lệ!");
                        case -2:
                            throw new Exception("Mật khẩu phải có ít nhất 9 ký tự!");
                        case -3:
                            throw new Exception("Mật khẩu phải có ít nhất 1 chữ in hoa!");
                        case -4:
                            throw new Exception("Mật khẩu phải có ít nhất 1 chữ thường!");
                        case -5:
                            throw new Exception("Mật khẩu phải có ít nhất 1 chữ số!");
                        case -6:
                            throw new Exception("Mật khẩu phải có ít nhất 1 ký tự đặc biệt!");
                        case 1:
                            // Thành công
                            break;
                        default:
                            throw new Exception($"Lỗi không xác định: {result}");
                    }
                }
            }
        }

        public bool Update(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("UPDATE TaiKhoan SET TenHienThi=@dn, IDVaiTro=@role WHERE TenDangNhap=@un", connection))
                {
                    cmd.Parameters.AddWithValue("@un", account.Username);
                    cmd.Parameters.AddWithValue("@dn", account.DisplayName);
                    cmd.Parameters.AddWithValue("@role", (int)account.Role);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("DELETE FROM TaiKhoan WHERE TenDangNhap=@un", connection))
                {
                    cmd.Parameters.AddWithValue("@un", username);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UsernameExists(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT 1 FROM TaiKhoan WHERE TenDangNhap=@un", connection))
                {
                    cmd.Parameters.AddWithValue("@un", username);
                    var result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }
    }
}
