using System;
using System.Collections.Generic;

namespace QLCafe.Application.DTOs.Order
{
    public class TableStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;

        // THÔNG TIN ORDER HIỆN TẠI
        public int? CurrentOrderId { get; set; }
        public List<TableOrderItemDto> OrderItems { get; set; } = new List<TableOrderItemDto>();
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }

    public class TableOrderItemDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}