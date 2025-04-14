using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prjPlayerCardTrader.Models;

namespace prjPlayerCardTrader.Data
{
    public class ApplicationDbConnect
    {
        private readonly string _connectionString;

        public ApplicationDbConnect(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SQL_CONNECTION_STRING");
        }

        public SqlConnection GetConnection() => new SqlConnection(_connectionString);
    }
}
