using System.Collections.Generic;
using QLCafe.Domain.Entities;

namespace QLCafe.Domain.Interfaces
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        Table GetTableById(int tableId);
        bool IsTableEmpty(int tableId);
        void UpdateTableStatus(int tableId, TableStatus status);

        List<Table> GetAvailableTables(); // Lấy danh sách bàn trống
        bool SwitchTable(int fromTableId, int toTableId); // Chuyển bàn
    }
}