using System.Collections.Generic;
using QLCafe.Domain.Entities;

namespace QLCafe.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetCurrentOrderByTable(int tableId);
        void AddItemToOrder(int tableId, int productId, int quantity, string userName, string notes = "");
        void RemoveItemFromOrder(int tableId, int productId, string userName);
        void UpdateItemQuantity(int tableId, int productId, int quantity, string userName);
        bool ProcessPayment(int tableId, decimal discountAmount, string userName);
    }
}