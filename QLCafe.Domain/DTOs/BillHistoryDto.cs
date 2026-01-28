using System;

namespace QLCafe.Domain.DTOs
{
    public class BillHistoryDto
    {
        public int BillId { get; set; }
        public string BillCode { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; } // 0: Ch?a thanh toán, 1: ?ã thanh toán
    }
}
