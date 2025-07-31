using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Main.Cross.Common;
using System.Data;

namespace Main.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {

        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("MainConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }

    }
}