using System;
using System.Collections.Generic;
using System.Linq;
using QLCafe.Application.DTOs.Order;
using QLCafe.Application.DTOs.Table;
using QLCafe.Application.Interfaces;
using QLCafe.Domain.Entities;
using QLCafe.Domain.Interfaces;

namespace QLCafe.Application.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IOrderRepository _orderRepository;

        public TableService(ITableRepository tableRepository, IOrderRepository orderRepository)
        {
            _tableRepository = tableRepository;
            _orderRepository = orderRepository;
        }

        public List<TableDto> GetTables()
        {
            var tables = _tableRepository.GetAllTables();

            return tables.Select(table => new TableDto
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status == TableStatus.Occupied ? "Có khách" : "Trống",
                StatusColor = table.Status == TableStatus.Occupied ? "Red" : "Green"
            }).ToList();
        }

        public List<TableStatusDto> GetTableStatusList()
        {
            var result = new List<TableStatusDto>();
            var tables = _tableRepository.GetAllTables();

            foreach (var table in tables)
            {
                var tableStatus = new TableStatusDto
                {
                    Id = table.Id,
                    Name = table.Name,
                    Status = table.Status == TableStatus.Occupied ? "Có khách" : "Trống",
                    StatusColor = table.Status == TableStatus.Occupied ? "Red" : "Green",
                    IsPaid = table.Status != TableStatus.Occupied
                };

                if (table.Status == TableStatus.Occupied)
                {
                    var currentOrder = _orderRepository.GetCurrentOrderByTable(table.Id);
                    if (currentOrder != null)
                    {
                        tableStatus.OrderItems = currentOrder.OrderDetails.Select(item => new TableOrderItemDto
                        {
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        }).ToList();

                        tableStatus.TotalAmount = currentOrder.OrderDetails.Sum(item => item.UnitPrice * item.Quantity);
                    }
                }

                result.Add(tableStatus);
            }

            return result;
        }

        public TableDto GetTableById(int tableId)
        {
            var table = _tableRepository.GetTableById(tableId);

            return new TableDto
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status == TableStatus.Occupied ? "Có khách" : "Trống",
                StatusColor = table.Status == TableStatus.Occupied ? "Red" : "Green"
            };
        }

        public bool IsTableEmpty(int tableId)
        {
            return _tableRepository.IsTableEmpty(tableId);
        }

        public void UpdateTableStatus(int tableId, string status)
        {
            var tableStatus = status == "Có khách" ? TableStatus.Occupied : TableStatus.Empty;
            _tableRepository.UpdateTableStatus(tableId, tableStatus);
        }

        // THÊM METHOD MỚI - Lấy danh sách bàn trống
        public List<TableDto> GetAvailableTables()
        {
            var availableTables = _tableRepository.GetAvailableTables();

            return availableTables.Select(table => new TableDto
            {
                Id = table.Id,
                Name = table.Name,
                Status = "Trống",
                StatusColor = "Green"
            }).ToList();
        }

        // THÊM METHOD MỚI - Chuyển bàn
        public bool SwitchTable(SwitchTableRequest request)
        {
            try
            {
                // Kiểm tra không được chuyển cùng một bàn
                if (request.FromTableId == request.ToTableId)
                    throw new Exception("Không thể chuyển cùng một bàn");

                // Kiểm tra bàn đích có trống không
                var targetTable = _tableRepository.GetTableById(request.ToTableId);
                if (targetTable == null)
                    throw new Exception("Bàn đích không tồn tại");

                if (targetTable.Status == TableStatus.Occupied)
                    throw new Exception("Bàn đích đang có khách");

                // Kiểm tra bàn nguồn có order không
                var currentOrder = _orderRepository.GetCurrentOrderByTable(request.FromTableId);
                if (currentOrder == null)
                    throw new Exception("Bàn nguồn không có order để chuyển");

                // Thực hiện chuyển bàn
                return _tableRepository.SwitchTable(request.FromTableId, request.ToTableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi chuyển bàn: {ex.Message}");
            }
        }
    }
}