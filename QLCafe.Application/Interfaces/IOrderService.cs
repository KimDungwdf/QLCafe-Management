using QLCafe.Application.DTOs.Order;

namespace QLCafe.Application.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrderByTable(int tableId);
        void AddItemToOrder(int tableId, int productId, int quantity, string notes = "");
        void RemoveItemFromOrder(int tableId, int productId);
        void UpdateItemQuantity(int tableId, int productId, int quantity);
        void Checkout(int tableId, decimal discount);
    }
}