using System;
using System.Collections.Generic;
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
                            // Table does not have numeric ID, using 0 placeholder
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

        public void Create(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, MatKhau, IDVaiTro) VALUES (@un,@dn,@pw,@role)", connection))
                {
                    cmd.Parameters.AddWithValue("@un", account.Username);
                    cmd.Parameters.AddWithValue("@dn", account.DisplayName);
                    cmd.Parameters.AddWithValue("@pw", account.Password);
                    cmd.Parameters.AddWithValue("@role", (int)account.Role);
                    cmd.ExecuteNonQuery();
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
