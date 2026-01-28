using System.Collections.Generic;

namespace QLCafe.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }

        // Tính tổng tiền hóa đơn (Cái này giữ lại được vì logic nó nằm ở OrderDto)
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
        public string Notes { get; set; } = string.Empty;

        // --- SỬA Ở ĐÂY: CHỈ GIỮ LẠI 1 CÁI TOTAL CÓ SET ---
        public decimal Total { get; set; }
    }
}