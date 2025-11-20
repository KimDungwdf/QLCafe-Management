using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Interfaces;

namespace QLCafe.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Order GetCurrentOrderByTable(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var bill = connection.QueryFirstOrDefault<dynamic>(
                    "SELECT IDHoaDon, TenDangNhap FROM HoaDon WHERE IDBan = @TableId AND TrangThai = 0",
                    new { TableId = tableId }
                );

                if (bill == null) return null;

                var orderDetails = connection.Query<OrderDetail>(
                    @"SELECT 
                        ct.IDChiTietHD as Id,
                        ct.IDHoaDon as OrderId,
                        ct.IDSanPham as ProductId,
                        sp.TenSanPham as ProductName,
                        ct.SoLuong as Quantity,
                        ct.DonGiaTaiThoiDiem as UnitPrice,
                        '' as Notes
                      FROM ChiTietHoaDon ct
                      JOIN SanPham sp ON ct.IDSanPham = sp.IDSanPham
                      WHERE ct.IDHoaDon = @BillId",
                    new { BillId = bill.IDHoaDon }
                ).ToList();

                return new Order
                {
                    Id = bill.IDHoaDon,
                    TableId = tableId,
                    CashierName = bill.TenDangNhap,
                    OrderDetails = orderDetails,
                    Status = OrderStatus.Pending
                };
            }
        }

        public void AddItemToOrder(int tableId, int productId, int quantity, string userName, string notes = "")
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "sp_AddBillDetail",
                    new
                    {
                        IDBan = tableId,
                        IDSanPham = productId,
                        SoLuong = quantity,
                        TenDangNhap = userName
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void RemoveItemFromOrder(int tableId, int productId, string userName)
        {
            AddItemToOrder(tableId, productId, 0, userName);
        }

        public void UpdateItemQuantity(int tableId, int productId, int quantity, string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var billId = connection.QueryFirstOrDefault<int?>(
                            "SELECT IDHoaDon FROM HoaDon WHERE IDBan = @TableId AND TrangThai = 0",
                            new { TableId = tableId },
                            transaction
                        );

                        if (billId == null)
                        {
                            throw new Exception("Không tìm thấy hóa đơn cho bàn này");
                        }

                        connection.Execute(
                            @"UPDATE ChiTietHoaDon 
                              SET SoLuong = @Quantity 
                              WHERE IDHoaDon = @BillId AND IDSanPham = @ProductId",
                            new
                            {
                                BillId = billId,
                                ProductId = productId,
                                Quantity = quantity
                            },
                            transaction
                        );

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // THÊM METHOD MỚI - Xử lý thanh toán
        public bool ProcessPayment(int tableId, decimal discountAmount, string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Execute(
                        "sp_Checkout",
                        new { IDBan = tableId, GiamGia = discountAmount },
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi thanh toán: {ex.Message}");
                }
            }
        }
    }
}