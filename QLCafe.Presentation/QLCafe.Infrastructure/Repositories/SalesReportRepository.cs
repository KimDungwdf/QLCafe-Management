using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using QLCafe.Domain.DTOs;

namespace QLCafe.Infrastructure.Repositories
{
    public class SalesReportRepository
    {
        private readonly string _connectionString;

        public SalesReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SalesReportDto GetSalesReport(DateTime fromDate, DateTime toDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    SELECT 
                        ISNULL(SUM(TongTien), 0) AS TotalRevenue,
                        COUNT(*) AS TotalOrders,
                        ISNULL(AVG(TongTien), 0) AS AverageOrderValue
                    FROM HoaDon
                    WHERE TrangThai = 1 
                        AND NgayLap >= @FromDate 
                        AND NgayLap < DATEADD(DAY, 1, @ToDate)";

                var parameters = new { FromDate = fromDate, ToDate = toDate };
                var result = connection.QueryFirstOrDefault<SalesReportDto>(sql, parameters);

                // Get previous period data for comparison
                var daysDiff = (toDate - fromDate).Days + 1;
                var prevFromDate = fromDate.AddDays(-daysDiff);
                var prevToDate = fromDate.AddDays(-1);

                var prevSql = @"
                    SELECT 
                        ISNULL(SUM(TongTien), 0) AS PreviousPeriodRevenue,
                        COUNT(*) AS PreviousPeriodOrders
                    FROM HoaDon
                    WHERE TrangThai = 1 
                        AND NgayLap >= @FromDate 
                        AND NgayLap < DATEADD(DAY, 1, @ToDate)";

                var prevParams = new { FromDate = prevFromDate, ToDate = prevToDate };
                var prevResult = connection.QueryFirstOrDefault<dynamic>(prevSql, prevParams);

                if (result != null && prevResult != null)
                {
                    result.PreviousPeriodRevenue = prevResult.PreviousPeriodRevenue;
                    result.PreviousPeriodOrders = prevResult.PreviousPeriodOrders;

                    // Calculate percentage change
                    if (prevResult.PreviousPeriodRevenue > 0)
                    {
                        result.RevenueChangePercent = ((result.TotalRevenue - prevResult.PreviousPeriodRevenue) / prevResult.PreviousPeriodRevenue) * 100;
                    }

                    if (prevResult.PreviousPeriodOrders > 0)
                    {
                        result.OrderChangePercent = ((result.TotalOrders - prevResult.PreviousPeriodOrders) / (decimal)prevResult.PreviousPeriodOrders) * 100;
                    }
                }

                return result ?? new SalesReportDto();
            }
        }

        public List<DailyRevenueDto> GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    SELECT 
                        CAST(NgayLap AS DATE) AS Date,
                        SUM(TongTien) AS Revenue
                    FROM HoaDon
                    WHERE TrangThai = 1 
                        AND NgayLap >= @FromDate 
                        AND NgayLap < DATEADD(DAY, 1, @ToDate)
                    GROUP BY CAST(NgayLap AS DATE)
                    ORDER BY Date";

                var parameters = new { FromDate = fromDate, ToDate = toDate };
                return connection.Query<DailyRevenueDto>(sql, parameters).ToList();
            }
        }

        public List<TopProductDto> GetTopProducts(DateTime fromDate, DateTime toDate, int topCount = 10)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    WITH ProductSales AS (
                        SELECT 
                            sp.TenSanPham AS ProductName,
                            SUM(cthd.SoLuong) AS QuantitySold,
                            SUM(cthd.SoLuong * sp.DonGia) AS Revenue
                        FROM ChiTietHoaDon cthd
                        INNER JOIN HoaDon hd ON cthd.IDHoaDon = hd.IDHoaDon
                        INNER JOIN SanPham sp ON cthd.IDSanPham = sp.IDSanPham
                        WHERE hd.TrangThai = 1 
                            AND hd.NgayLap >= @FromDate 
                            AND hd.NgayLap < DATEADD(DAY, 1, @ToDate)
                        GROUP BY sp.TenSanPham
                    ),
                    TotalRevenue AS (
                        SELECT SUM(Revenue) AS Total FROM ProductSales
                    )
                    SELECT TOP (@TopCount)
                        ROW_NUMBER() OVER (ORDER BY Revenue DESC) AS Rank,
                        ProductName,
                        QuantitySold,
                        Revenue,
                        CASE 
                            WHEN (SELECT Total FROM TotalRevenue) > 0 
                            THEN (Revenue * 100.0 / (SELECT Total FROM TotalRevenue))
                            ELSE 0 
                        END AS Percentage
                    FROM ProductSales
                    ORDER BY Revenue DESC";

                var parameters = new { FromDate = fromDate, ToDate = toDate, TopCount = topCount };
                return connection.Query<TopProductDto>(sql, parameters).ToList();
            }
        }

        public List<EmployeeRevenueDto> GetEmployeeRevenue(DateTime fromDate, DateTime toDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    WITH EmployeeSales AS (
                        SELECT 
                            tk.TenHienThi AS EmployeeName,
                            SUM(hd.TongTien) AS Revenue
                        FROM HoaDon hd
                        INNER JOIN TaiKhoan tk ON hd.TenDangNhap = tk.TenDangNhap
                        WHERE hd.TrangThai = 1 
                            AND hd.NgayLap >= @FromDate 
                            AND hd.NgayLap < DATEADD(DAY, 1, @ToDate)
                        GROUP BY tk.TenHienThi
                    ),
                    TotalRevenue AS (
                        SELECT SUM(Revenue) AS Total FROM EmployeeSales
                    )
                    SELECT 
                        EmployeeName,
                        Revenue,
                        CASE 
                            WHEN (SELECT Total FROM TotalRevenue) > 0 
                            THEN (Revenue * 100.0 / (SELECT Total FROM TotalRevenue))
                            ELSE 0 
                        END AS Percentage
                    FROM EmployeeSales
                    ORDER BY Revenue DESC";

                var parameters = new { FromDate = fromDate, ToDate = toDate };
                return connection.Query<EmployeeRevenueDto>(sql, parameters).ToList();
            }
        }
    }
}
