using System.Collections.Generic;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.DTOs.Table;
using System.Threading.Tasks;

namespace QLCafe.Application.Interfaces
{
    public interface ITableService
    {
        List<TableDto> GetTables();
        List<TableStatusDto> GetTableStatusList();
        TableDto GetTableById(int tableId);
        bool IsTableEmpty(int tableId);
        void UpdateTableStatus(int tableId, string status);

        // THÊM CÁC METHOD CHO CHỨC NĂNG CHUYỂN BÀN
        List<TableDto> GetAvailableTables(); // Lấy danh sách bàn trống
        bool SwitchTable(SwitchTableRequest request); // Chuyển bàn
    }
}