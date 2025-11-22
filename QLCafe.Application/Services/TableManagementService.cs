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
    // Service quản lý bàn cho màn Organization (thêm, sửa tên, xóa)
    public class TableManagementService : ITableManagementService
    {
        private readonly ITableManagementRepository _repo;
        private readonly IOrderRepository _orderRepo;

        public TableManagementService(ITableManagementRepository repository, IOrderRepository orderRepository)
        {
            _repo = repository;
            _orderRepo = orderRepository;
        }

        public List<TableAdminItemDto> GetAll()
        {
            var tables = _repo.GetAllTables();
            var list = new List<TableAdminItemDto>();
            foreach (var t in tables)
            {
                decimal total = 0;
                if (t.Status == TableStatus.Occupied)
                {
                    var order = _orderRepo.GetCurrentOrderByTable(t.Id);
                    if (order != null && order.OrderDetails != null)
                    {
                        total = order.OrderDetails.Sum(d => d.UnitPrice * d.Quantity);
                    }
                }
                list.Add(new TableAdminItemDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    IsOccupied = t.Status == TableStatus.Occupied,
                    StatusText = t.Status == TableStatus.Occupied ? "Có khách" : "Trống",
                    TotalAmount = total
                });
            }
            return list;
        }

        public bool Rename(int id, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) return false;
            newName = newName.Trim();
            return _repo.UpdateTableName(id, newName);
        }

        public bool Delete(int id, out string error)
        {
            error = null;

            // Không cho phép xóa nếu bàn đang có khách
            if (!_repo.IsTableEmpty(id))
            {
                error = "Bàn đang có khách hoặc đang được sử dụng.";
                return false;
            }

            var ok = _repo.DeleteTable(id);
            if (!ok)
            {
                error = "Không thể xóa bàn (có thể đang có hóa đơn chưa thanh toán).";
            }
            return ok;
        }

        public int Create(string name, out string error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Tên bàn không được để trống";
                return -1;
            }
            name = name.Trim();

            var id = _repo.CreateTable(name);
            if (id <= 0)
            {
                error = "Tên bàn đã tồn tại hoặc lỗi hệ thống";
            }
            return id;
        }
    }
}