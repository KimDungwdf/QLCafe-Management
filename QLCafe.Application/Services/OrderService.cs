using System;
using System.Collections.Generic;
using System.Linq;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;

namespace QLCafe.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly Dictionary<int, OrderDto> _orders = new Dictionary<int, OrderDto>();

        public OrderDto GetOrderByTable(int tableId)
        {
            if (_orders.ContainsKey(tableId))
            {
                return _orders[tableId];
            }

            // Tạo order mới nếu chưa có
            var tableService = new TableService();
            var table = tableService.GetTableById(tableId);

            return new OrderDto
            {
                TableId = tableId,
                TableName = table.Name,
                Items = new List<OrderItemDto>(),
                SubTotal = 0,
                Discount = 0
            };
        }

        public void AddItemToOrder(int tableId, int productId, int quantity, string notes = "")
        {
            var order = GetOrderByTable(tableId);
            var productService = new ProductService();
            var product = productService.GetProducts().FirstOrDefault(p => p.Id == productId);

            if (product == null) return;

            var existingItem = order.Items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                // Cập nhật số lượng nếu đã có
                existingItem.Quantity += quantity;
            }
            else
            {
                // Thêm mới
                order.Items.Add(new OrderItemDto
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Notes = notes
                });
            }

            UpdateOrderTotal(order);
            _orders[tableId] = order;
        }

        public void RemoveItemFromOrder(int tableId, int productId)
        {
            var order = GetOrderByTable(tableId);
            order.Items.RemoveAll(item => item.ProductId == productId);
            UpdateOrderTotal(order);
            _orders[tableId] = order;
        }

        public void UpdateItemQuantity(int tableId, int productId, int quantity)
        {
            if (quantity <= 0)
            {
                RemoveItemFromOrder(tableId, productId);
                return;
            }

            var order = GetOrderByTable(tableId);
            var item = order.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity;
                UpdateOrderTotal(order);
                _orders[tableId] = order;
            }
        }

        public void Checkout(int tableId, decimal discount)
        {
            var order = GetOrderByTable(tableId);
            order.Discount = discount;
            UpdateOrderTotal(order);

            // Mock thanh toán
            Console.WriteLine($"Thanh toán bàn {tableId}: {order.Total.ToString("N0")} đ");
            _orders.Remove(tableId); // Xóa order sau khi thanh toán
        }

        private void UpdateOrderTotal(OrderDto order)
        {
            order.SubTotal = order.Items.Sum(item => item.Total);
        }
    }
}