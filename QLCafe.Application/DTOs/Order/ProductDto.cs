using System;

namespace QLCafe.Application.DTOs.Order
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string FormattedPrice
        {
            get { return Price.ToString("N0") + " đ"; }
        }
    }
}