using System;

namespace QLCafe.Domain.DTOs
{
    public class TopProductDto
    {
        public int Rank { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
        public decimal Percentage { get; set; }
    }
}
