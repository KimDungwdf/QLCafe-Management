using System;
using System.Collections.Generic;
using QLCafe.Domain.DTOs;

namespace QLCafe.Application.Interfaces
{
    public interface ISalesReportService
    {
        SalesReportDto GetSalesReport(DateTime fromDate, DateTime toDate);
        List<DailyRevenueDto> GetDailyRevenue(DateTime fromDate, DateTime toDate);
        List<TopProductDto> GetTopProducts(DateTime fromDate, DateTime toDate, int topCount = 10);
        List<EmployeeRevenueDto> GetEmployeeRevenue(DateTime fromDate, DateTime toDate);
    }
}
