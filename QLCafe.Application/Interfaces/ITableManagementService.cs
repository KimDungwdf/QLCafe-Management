using System.Collections.Generic;
using QLCafe.Application.DTOs.Table;

namespace QLCafe.Application.Interfaces
{
    // Service dành cho Organization (quản lý bàn: thêm, sửa tên, xóa)
    public interface ITableManagementService
    {
        List<TableAdminItemDto> GetAll();
        bool Rename(int id, string newName);
        bool Delete(int id, out string error);
        int Create(string name, out string error); // Thêm bàn
    }
}