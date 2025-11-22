using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.Application.DTOs.Table
{
    public class TableManagement
    {
    }

    public class TableAdminItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StatusText { get; set; }
        public bool IsOccupied { get; set; }
        public decimal TotalAmount { get; set; } // tổng tiền hiện tại của bàn
        public List<TableAdminOrderItemDto> OrderItems { get; set; } = new List<TableAdminOrderItemDto>();
    }

    public class TableAdminOrderItemDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
