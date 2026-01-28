using System;

namespace QLCafe.Domain.DTOs
{
    public class SalesReportDto
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public decimal PreviousPeriodRevenue { get; set; }
        public int PreviousPeriodOrders { get; set; }
        public decimal RevenueChangePercent { get; set; }
        public decimal OrderChangePercent { get; set; }
    }
}
