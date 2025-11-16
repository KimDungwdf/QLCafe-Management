using System;
using System.Collections.Generic;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.Interfaces;

namespace QLCafe.Application.Services
{
    public class TableService : ITableService
    {
        public List<TableDto> GetTables()
        {
            // Mock data - 10 bàn (5 trống, 5 có khách)
            return new List<TableDto>
            {
                new TableDto { Id = 1, Name = "Bàn 1", Status = "Trống", StatusColor = "Green" },
                new TableDto { Id = 2, Name = "Bàn 2", Status = "Có khách", StatusColor = "Red" },
                new TableDto { Id = 3, Name = "Bàn 3", Status = "Trống", StatusColor = "Green" },
                new TableDto { Id = 4, Name = "Bàn 4", Status = "Có khách", StatusColor = "Red" },
                new TableDto { Id = 5, Name = "Bàn 5", Status = "Trống", StatusColor = "Green" },
                new TableDto { Id = 6, Name = "Bàn 6", Status = "Có khách", StatusColor = "Red" },
                new TableDto { Id = 7, Name = "Bàn 7", Status = "Trống", StatusColor = "Green" },
                new TableDto { Id = 8, Name = "Bàn 8", Status = "Có khách", StatusColor = "Red" },
                new TableDto { Id = 9, Name = "Bàn 9", Status = "Trống", StatusColor = "Green" },
                new TableDto { Id = 10, Name = "Bàn 10", Status = "Có khách", StatusColor = "Red" }
            };
        }

        public TableDto GetTableById(int tableId)
        {
            var tables = GetTables();
            return tables.Find(t => t.Id == tableId)
                   ?? new TableDto { Id = tableId, Name = "Bàn " + tableId, Status = "Không tồn tại", StatusColor = "Gray" };
        }

        public void UpdateTableStatus(int tableId, string status)
        {
            // Mock - trong thực tế sẽ cập nhật database
            Console.WriteLine($"Cập nhật bàn {tableId} thành trạng thái: {status}");
        }
    }
}