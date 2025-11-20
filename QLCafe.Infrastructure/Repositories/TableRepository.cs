using Dapper;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QLCafe.Infrastructure.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly string _connectionString;

        public TableRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Table> GetAllTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var tables = connection.Query<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban"
                ).ToList();

                return tables;
            }
        }

        public Table GetTableById(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var table = connection.QueryFirstOrDefault<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban WHERE IDBan = @TableId",
                    new { TableId = tableId }
                );

                return table ?? new Table { Id = tableId, Name = $"Bàn {tableId}", Status = TableStatus.Empty };
            }
        }

        public bool IsTableEmpty(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var status = connection.QueryFirstOrDefault<int>(
                    "SELECT TrangThai FROM Ban WHERE IDBan = @TableId",
                    new { TableId = tableId }
                );

                return status == 0; // 0 = Trống, 1 = Có khách
            }
        }

        public void UpdateTableStatus(int tableId, TableStatus status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "UPDATE Ban SET TrangThai = @Status WHERE IDBan = @TableId",
                    new { TableId = tableId, Status = (int)status }
                );
            }
        }

        // THÊM METHOD MỚI - Lấy danh sách bàn trống
        public List<Table> GetAvailableTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var tables = connection.Query<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban WHERE TrangThai = 0 ORDER BY TenBan",
                    commandType: CommandType.Text
                ).ToList();

                return tables;
            }
        }

        // THÊM METHOD MỚI - Chuyển bàn
        public bool SwitchTable(int fromTableId, int toTableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Execute(
                        "sp_SwitchTable",
                        new { IDBan_Tu = fromTableId, IDBan_Den = toTableId },
                        commandType: CommandType.StoredProcedure
                    );
                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi chuyển bàn: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi không xác định: {ex.Message}");
                }
            }
        }
    }
}