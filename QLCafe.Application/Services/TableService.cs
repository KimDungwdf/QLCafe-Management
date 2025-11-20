using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;

namespace QLCafe.Application.Services
{
    public class TableService : ITableService
    {
        private readonly string _connectionString;

        public TableService()
        {
            // Lưu ý: Nên lấy connection string từ App.config hoặc Program.ConnectionString thay vì hard-code thế này
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLCafe;Integrated Security=True";
        }

        public List<TableDto> GetTables()
        {
            var tables = new List<TableDto>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("sp_GetTableList", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var table = new TableDto
                        {
                            // SỬA LỖI: Dùng Convert.ToInt32(reader["TenCot"]) thay vì reader.GetInt32("TenCot")
                            Id = Convert.ToInt32(reader["IDBan"]),
                            Name = reader["TenBan"].ToString(),
                            Status = Convert.ToInt32(reader["TrangThai"]) == 1 ? "Có khách" : "Trống",
                            StatusColor = Convert.ToInt32(reader["TrangThai"]) == 1 ? "Red" : "Green"
                        };
                        tables.Add(table);
                    }
                }
            }

            return tables;
        }

        public List<TableStatusDto> GetTableStatusList()
        {
            var result = new List<TableStatusDto>();

            var tables = GetTables();

            foreach (var table in tables)
            {
                var tableStatus = new TableStatusDto
                {
                    Id = table.Id,
                    Name = table.Name,
                    Status = table.Status,
                    StatusColor = table.StatusColor,
                    IsPaid = table.Status != "Có khách"
                };

                if (table.Status == "Có khách")
                {
                    var orderInfo = GetCurrentOrderInfo(table.Id);
                    if (orderInfo != null)
                    {
                        tableStatus.CurrentOrderId = orderInfo.OrderId;
                        tableStatus.OrderItems = orderInfo.Items;
                        tableStatus.TotalAmount = orderInfo.TotalAmount;
                    }
                }

                result.Add(tableStatus);
            }

            return result;
        }

        private OrderInfoDto GetCurrentOrderInfo(int tableId)
        {
            var orderInfo = new OrderInfoDto();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("sp_GetBillInfoByTableID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDBan", tableId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    decimal totalAmount = 0;

                    while (reader.Read())
                    {
                        var item = new TableOrderItemDto
                        {
                            // SỬA LỖI: Dùng Indexer [] và Convert
                            ProductName = reader["TenSanPham"].ToString(),
                            Quantity = Convert.ToInt32(reader["SoLuong"]),
                            UnitPrice = Convert.ToDecimal(reader["DonGiaTaiThoiDiem"])
                        };

                        orderInfo.Items.Add(item);

                        // SỬA LỖI: Lấy ThanhTien
                        totalAmount += Convert.ToDecimal(reader["ThanhTien"]);
                    }

                    orderInfo.TotalAmount = totalAmount;

                    if (orderInfo.Items.Count > 0)
                    {
                        orderInfo.OrderId = GetCurrentOrderId(tableId);
                        return orderInfo;
                    }
                }
            }

            return null;
        }

        private int GetCurrentOrderId(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT IDHoaDon FROM HoaDon WHERE IDBan = @IDBan AND TrangThai = 0", connection))
            {
                command.Parameters.AddWithValue("@IDBan", tableId);

                connection.Open();
                var result = command.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        public TableDto GetTableById(int tableId)
        {
            var tables = GetTables();
            return tables.Find(t => t.Id == tableId)
                    ?? new TableDto { Id = tableId, Name = "Bàn " + tableId, Status = "Không tồn tại", StatusColor = "Gray" };
        }

        public void UpdateTableStatus(int tableId, string status)
        {
            // Hàm này hiện tại chỉ log ra console, sau này bạn có thể gọi SP cập nhật DB nếu cần
            Console.WriteLine($"Cập nhật bàn {tableId} thành trạng thái: {status}");
        }
    }

    internal class OrderInfoDto
    {
        public int OrderId { get; set; }
        public List<TableOrderItemDto> Items { get; set; } = new List<TableOrderItemDto>();
        public decimal TotalAmount { get; set; }
    }
}