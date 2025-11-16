using System.Collections.Generic;
using QLCafe.Application.DTOs.Order;

namespace QLCafe.Application.Interfaces
{
    public interface ITableService
    {
        List<TableDto> GetTables();
        TableDto GetTableById(int tableId);
        void UpdateTableStatus(int tableId, string status);
    }
}