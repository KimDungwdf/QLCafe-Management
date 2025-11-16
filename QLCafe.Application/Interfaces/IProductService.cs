using System.Collections.Generic;
using QLCafe.Application.DTOs.Order;

namespace QLCafe.Application.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        List<ProductDto> GetProductsByCategory(string categoryName);
        List<string> GetCategories();
    }
}