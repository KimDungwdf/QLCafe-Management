using System.Collections.Generic;
using QLCafe.Domain.Entities;

namespace QLCafe.Domain.Interfaces
{
    public interface IOrderRepository
    {
        // Lấy hóa đơn hiện tại của bàn
        Order GetCurrentOrderByTable(int tableId);

        // Thêm món
        void AddItemToOrder(int tableId, int productId, int quantity, string userName, string notes = "");

        // Xóa món
        void RemoveItemFromOrder(int tableId, int productId, string userName);

        // Cập nhật số lượng
        void UpdateItemQuantity(int tableId, int productId, int quantity, string userName);

        // THANH TOÁN (Chỉ giữ lại hàm này, bỏ ProcessPayment)
        bool Checkout(int tableId, decimal discount, string paymentMethod, string userName);
        // Thêm vào IOrderRepository.cs
        string CheckStock(int productId, int quantity);
    }
}