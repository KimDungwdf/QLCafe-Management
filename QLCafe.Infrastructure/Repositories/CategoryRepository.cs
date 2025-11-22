using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCafe.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Exists(string name)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT 1 FROM DanhMucMon WHERE TenDanhMuc=@n", cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public int Create(string name)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand(
                    "INSERT INTO DanhMucMon (TenDanhMuc) VALUES (@n); SELECT SCOPE_IDENTITY();", cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    var idObj = cmd.ExecuteScalar();
                    return Convert.ToInt32(idObj);
                }
            }
        }

        public List<string> GetAllNames()
        {
            var list = new List<string>();
            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT TenDanhMuc FROM DanhMucMon ORDER BY TenDanhMuc", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(rd.GetString(0));
                }
            }
            return list;
        }

        public List<(int Id, string Name)> GetAllPairs()
        {
            var list = new List<(int, string)>();
            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT IDDanhMuc,TenDanhMuc FROM DanhMucMon ORDER BY TenDanhMuc", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add((rd.GetInt32(0), rd.GetString(1)));
                }
            }
            return list;
        }

        public bool DeleteCategoryAndProducts(int categoryId)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();

                // Ki?m tra b?t k? s?n ph?m nào trong danh m?c ?ang n?m trong hóa ??n ch?a thanh toán
                using (var check = new SqlCommand(@"SELECT COUNT(*) FROM ChiTietHoaDon ct 
JOIN SanPham sp ON ct.IDSanPham = sp.IDSanPham 
JOIN HoaDon h ON ct.IDHoaDon = h.IDHoaDon 
WHERE sp.IDDanhMuc = @cid AND h.TrangThai = 0", cn))
                {
                    check.Parameters.AddWithValue("@cid", categoryId);
                    int used = Convert.ToInt32(check.ExecuteScalar());
                    if (used > 0) return false; // Không cho xóa
                }

                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        using (var cmdDelProducts = new SqlCommand("DELETE FROM SanPham WHERE IDDanhMuc=@cid", cn, tx))
                        {
                            cmdDelProducts.Parameters.AddWithValue("@cid", categoryId);
                            cmdDelProducts.ExecuteNonQuery();
                        }
                        using (var cmdDelCat = new SqlCommand("DELETE FROM DanhMucMon WHERE IDDanhMuc=@cid", cn, tx))
                        {
                            cmdDelCat.Parameters.AddWithValue("@cid", categoryId);
                            int affected = cmdDelCat.ExecuteNonQuery();
                            tx.Commit();
                            return affected > 0;
                        }
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}