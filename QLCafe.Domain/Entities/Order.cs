using System;
using System.Collections.Generic;

namespace QLCafe.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string CashierName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }

    public enum OrderStatus
    {
        Pending = 0,    // Đang order
        Paid = 1        // Đã thanh toán
    }
}