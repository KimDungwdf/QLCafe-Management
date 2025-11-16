using System.Data.SqlClient;

namespace QLCafe.Infrastructure.Data
{
    public class QLCafeDbContext
    {
        private readonly string _connectionString;

        public QLCafeDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}