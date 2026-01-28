using Dapper;
using QLCafe.Domain.DTOs; // <--- QUAN TRỌNG: Dùng DTO từ Domain
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QLCafe.Infrastructure.Repositories
{
    public class InventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (InventoryDashboardDto Dashboard, List<InventoryDto> Items) GetInventoryData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var multi = connection.QueryMultiple("sp_GetInventoryDashboard", commandType: CommandType.StoredProcedure))
                {
                    var dashboard = multi.Read<InventoryDashboardDto>().FirstOrDefault();
                    var items = multi.Read<InventoryDto>().ToList();
                    return (dashboard, items);
                }
            }
        }
    }
}