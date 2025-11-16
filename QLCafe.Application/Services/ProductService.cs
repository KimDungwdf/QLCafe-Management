using System;
using System.Collections.Generic;
using System.Linq;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;

namespace QLCafe.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly List<ProductDto> _products;

        public ProductService()
        {
            // Mock data - 7 sản phẩm
            _products = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Cà phê Đen", CategoryName = "Cà phê", Price = 25000 },
                new ProductDto { Id = 2, Name = "Cà phê Sữa", CategoryName = "Cà phê", Price = 30000 },
                new ProductDto { Id = 3, Name = "Bạc Xỉu", CategoryName = "Cà phê", Price = 35000 },
                new ProductDto { Id = 4, Name = "Trà Chanh", CategoryName = "Nước ép & Trà", Price = 20000 },
                new ProductDto { Id = 5, Name = "Nước ép Cam", CategoryName = "Nước ép & Trà", Price = 35000 },
                new ProductDto { Id = 6, Name = "Bánh Mì Chảo", CategoryName = "Đồ ăn vặt", Price = 45000 },
                new ProductDto { Id = 7, Name = "Hướng Dương", CategoryName = "Đồ ăn vặt", Price = 15000 }
            };
        }

        public List<ProductDto> GetProducts()
        {
            return _products;
        }

        public List<ProductDto> GetProductsByCategory(string categoryName)
        {
            return _products.Where(p => p.CategoryName == categoryName).ToList();
        }

        public List<string> GetCategories()
        {
            return _products.Select(p => p.CategoryName).Distinct().ToList();
        }
    }
}