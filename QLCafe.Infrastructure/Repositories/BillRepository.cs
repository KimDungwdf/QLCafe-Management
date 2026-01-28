using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using QLCafe.Domain.DTOs;

namespace QLCafe.Infrastructure.Repositories
{
    public class BillRepository
    {
        private readonly string _connectionString;

        public BillRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BillHistoryDto> GetBillHistory(DateTime fromDate, DateTime toDate, int? tableId = null, int? status = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    SELECT 
                        hd.IDHoaDon AS BillId,
                        'HD' + RIGHT('0000' + CAST(hd.IDHoaDon AS VARCHAR), 4) AS BillCode,
                        hd.IDBan AS TableId,
                        b.TenBan AS TableName,
                        hd.NgayLap AS OrderDate,
                        hd.TongTien AS TotalAmount,
                        hd.GiamGia AS Discount,
                        tk.TenHienThi AS EmployeeName,
                        hd.TrangThai AS StatusCode,
                        CASE 
                            WHEN hd.TrangThai = 0 THEN N'?ang s? d?ng'
                            WHEN hd.TrangThai = 1 THEN N'Hoàn thành'
                            ELSE N'H?y'
                        END AS Status
                    FROM HoaDon hd
                    INNER JOIN Ban b ON hd.IDBan = b.IDBan
                    INNER JOIN TaiKhoan tk ON hd.TenDangNhap = tk.TenDangNhap
                    WHERE hd.NgayLap >= @FromDate 
                        AND hd.NgayLap < DATEADD(DAY, 1, @ToDate)";

                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", fromDate);
                parameters.Add("@ToDate", toDate);

                if (tableId.HasValue && tableId.Value > 0)
                {
                    sql += " AND hd.IDBan = @TableId";
                    parameters.Add("@TableId", tableId.Value);
                }

                if (status.HasValue && status.Value >= 0)
                {
                    sql += " AND hd.TrangThai = @Status";
                    parameters.Add("@Status", status.Value);
                }

                sql += " ORDER BY hd.NgayLap DESC";

                return connection.Query<BillHistoryDto>(sql, parameters).ToList();
            }
        }

        public List<string> GetAllTableNames()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT TenBan FROM Ban ORDER BY TenBan";
                return connection.Query<string>(sql).ToList();
            }
        }
    }
}
