using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductsAPI.Database
{
    public class ApplicationDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ApplicationDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
