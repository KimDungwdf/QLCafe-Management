using QLCafe.Domain.DTOs; // <--- QUAN TRỌNG: Dùng DTO từ Domain
using QLCafe.Infrastructure.Repositories;
using System.Collections.Generic;

namespace QLCafe.Application.Services
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public (InventoryDashboardDto, List<InventoryDto>) GetDashboardData()
        {
            return _inventoryRepository.GetInventoryData();
        }
    }
}