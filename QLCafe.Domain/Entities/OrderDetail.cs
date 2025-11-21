using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; // Thêm property này
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
