using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCafe.Infrastructure.Repositories
{
    public class MenuProductRepository
    {
        private readonly string _cs;

        public MenuProductRepository(string cs)
        {
            _cs = cs;
        }

        public class MenuProduct
        {
            public int Id;
            public string Name;
            public string CategoryName;
            public decimal Price;
        }

        public List<MenuProduct> GetAll()
        {
            var list = new List<MenuProduct>();
            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT p.IDSanPham,p.TenSanPham,c.TenDanhMuc,p.DonGia FROM SanPham p JOIN DanhMucMon c ON p.IDDanhMuc=c.IDDanhMuc ORDER BY c.TenDanhMuc,p.TenSanPham", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new MenuProduct
                        {
                            Id = rd.GetInt32(0),
                            Name = rd.GetString(1),
                            CategoryName = rd.GetString(2),
                            Price = rd.GetDecimal(3)
                        });
                    }
                }
            }
            return list;
        }

        public int Insert(string name, int categoryId, decimal price)
        {
            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();
                using (var cmd = new SqlCommand("INSERT INTO SanPham (TenSanPham,IDDanhMuc,DonGia) VALUES (@n,@cid,@p);SELECT SCOPE_IDENTITY();", cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@cid", categoryId);
                    cmd.Parameters.AddWithValue("@p", price);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Delete(int id)
        {
            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();
                // Ki?m tra s?n ph?m có n?m trong hóa ??n ch?a thanh toán
                using (var check = new SqlCommand("SELECT COUNT(*) FROM ChiTietHoaDon ct JOIN HoaDon h ON ct.IDHoaDon=h.IDHoaDon WHERE ct.IDSanPham=@id AND h.TrangThai=0", cn))
                {
                    check.Parameters.AddWithValue("@id", id);
                    int used = Convert.ToInt32(check.ExecuteScalar());
                    if (used > 0) return false;
                }
                using (var cmd = new SqlCommand("DELETE FROM SanPham WHERE IDSanPham=@id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteByCategory(int categoryId)
        {
            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();
                using (var cmd = new SqlCommand("DELETE FROM SanPham WHERE IDDanhMuc=@cid", cn))
                {
                    cmd.Parameters.AddWithValue("@cid", categoryId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}