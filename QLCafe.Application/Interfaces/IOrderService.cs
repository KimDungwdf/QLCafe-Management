using QLCafe.Application.DTOs.Order;

namespace QLCafe.Application.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrderByTable(int tableId);
        OrderDto GetCurrentOrderByTable(int tableId);
        void AddItemToOrder(int tableId, int productId, int quantity, string userName, string notes = "");
        void RemoveItemFromOrder(int tableId, int productId, string userName);
        void UpdateItemQuantity(int tableId, int productId, int quantity, string userName);

        // THÊM PHƯƠNG THỨC THANH TOÁN
        bool Checkout(int tableId, decimal discount, string paymentMethod, string userName);
        string CheckStockAvailability(int productId, int quantity);
        decimal CalculateChange(decimal totalAmount, decimal customerPayment);
    }

}