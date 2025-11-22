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
    // Repository cho ch?c n?ng qu?n lý bàn (s?a tên, xóa, thêm)
    public class TableManagementRepository : ITableManagementRepository
    {
        private readonly string _connectionString;

        public TableManagementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Table> GetAllTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban ORDER BY TenBan"
                ).ToList();
            }
        }

        public Table GetTableById(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban WHERE IDBan = @Id",
                    new { Id = tableId }
                );
            }
        }

        public bool IsTableEmpty(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var status = connection.QueryFirstOrDefault<int>(
                    "SELECT TrangThai FROM Ban WHERE IDBan = @Id",
                    new { Id = tableId }
                );
                return status == 0;
            }
        }

        public void UpdateTableStatus(int tableId, TableStatus status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "UPDATE Ban SET TrangThai = @Status WHERE IDBan = @Id",
                    new { Id = tableId, Status = (int)status }
                );
            }
        }

        public List<Table> GetAvailableTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Table>(
                    "SELECT IDBan as Id, TenBan as Name, TrangThai as Status FROM Ban WHERE TrangThai = 0 ORDER BY TenBan"
                ).ToList();
            }
        }

        public bool SwitchTable(int fromTableId, int toTableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_SwitchTable", new { IDBan_Tu = fromTableId, IDBan_Den = toTableId }, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public bool UpdateTableName(int tableId, string newName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var affected = connection.Execute(
                    "UPDATE Ban SET TenBan = @Name WHERE IDBan = @Id",
                    new { Name = newName, Id = tableId }
                );
                return affected > 0;
            }
        }

        public bool DeleteTable(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var exists = connection.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM HoaDon WHERE IDBan = @Id AND TrangThai = 0",
                    new { Id = tableId }
                );
                if (exists > 0) return false;

                var affected = connection.Execute("DELETE FROM Ban WHERE IDBan = @Id", new { Id = tableId });
                return affected > 0;
            }
        }

        public int CreateTable(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Ki?m tra trùng tên
                var dup = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Ban WHERE TenBan = @Name", new { Name = name });
                if (dup > 0) return -1;

                // Thêm bàn, m?c ??nh TrangThai = 0 (Tr?ng)
                var sql = @"INSERT INTO Ban(TenBan, TrangThai) VALUES(@Name, 0); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                var id = connection.ExecuteScalar<int>(sql, new { Name = name });
                return id;
            }
        }
    }
}
