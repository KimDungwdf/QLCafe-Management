using System.Collections.Generic;

namespace QLCafe.Application.DTOs.Order
{
    public class OrderDto
    {
        public int TableId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total
        {
            get { return SubTotal - Discount; }
        }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total
        {
            get { return Quantity * UnitPrice; }
        }
        public string Notes { get; set; } = string.Empty; // FIXED: Không dùng ?
    }
}