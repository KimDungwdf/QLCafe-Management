using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLCafe.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDto GetOrderByTable(int tableId)
        {
            return GetCurrentOrderByTable(tableId);
        }

        public OrderDto GetCurrentOrderByTable(int tableId)
        {
            try
            {
                var currentOrder = _orderRepository.GetCurrentOrderByTable(tableId);

                // TRƯỜNG HỢP 1: Bàn chưa có hóa đơn (Mới vào)
                if (currentOrder == null)
                {
                    return new OrderDto
                    {
                        Id = 0, // <--- SỬA LỖI Ở ĐÂY: Chưa có thì ID là 0
                        TableId = tableId,
                        Items = new List<OrderItemDto>(),
                        SubTotal = 0,
                        Discount = 0
                    };
                }

                // TRƯỜNG HỢP 2: Đã có hóa đơn
                return new OrderDto
                {
                    Id = currentOrder.Id, // <--- QUAN TRỌNG: Phải gán ID thật vào đây
                    TableId = tableId,
                    Items = currentOrder.OrderDetails.Select(item => new OrderItemDto
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Notes = item.Notes,
                        // Tính tổng tiền từng dòng (Thành tiền = Giá * SL)
                        Total = item.UnitPrice * item.Quantity
                    }).ToList(),
                    SubTotal = currentOrder.OrderDetails.Sum(item => item.UnitPrice * item.Quantity),
                    Discount = 0
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy order hiện tại: {ex.Message}");
            }
        }

        public void AddItemToOrder(int tableId, int productId, int quantity, string userName, string notes = "")
        {
            try
            {
                _orderRepository.AddItemToOrder(tableId, productId, quantity, userName, notes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm món: {ex.Message}");
            }
        }

        public void RemoveItemFromOrder(int tableId, int productId, string userName)
        {
            try
            {
                _orderRepository.RemoveItemFromOrder(tableId, productId, userName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa món: {ex.Message}");
            }
        }

        public void UpdateItemQuantity(int tableId, int productId, int quantity, string userName)
        {
            try
            {
                _orderRepository.UpdateItemQuantity(tableId, productId, quantity, userName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật số lượng: {ex.Message}");
            }
        }

        // Hàm cũ (giữ lại để tránh lỗi Interface nếu chưa sửa Interface, nhưng throw Exception)
        public void Checkout(int tableId, decimal discount, string userName)
        {
            throw new NotImplementedException("Vui lòng sử dụng hàm Checkout có tham số PaymentMethod");
        }

        // HÀM THANH TOÁN CHÍNH THỨC
        public bool Checkout(int tableId, decimal discount, string paymentMethod, string userName)
        {
            try
            {
                return _orderRepository.Checkout(tableId, discount, paymentMethod, userName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thanh toán: {ex.Message}");
            }
        }

        public decimal CalculateChange(decimal totalAmount, decimal customerPayment)
        {
            if (customerPayment < totalAmount)
                throw new Exception("Số tiền khách đưa không đủ");

            return customerPayment - totalAmount;
        }

        public string CheckStockAvailability(int productId, int quantity)
        {
            return _orderRepository.CheckStock(productId, quantity);
        }
    }
}