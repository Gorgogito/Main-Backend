using Dapper;
using Main.Cross.Common;
using Main.Infrastructure.Interface;
using System.Data;

namespace Main.Infrastructure.Repository
{

    public class EncryptingRepository : IEncryptingRepository
    {

        private readonly IConnectionFactory _connectionFactory;

        public EncryptingRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos

        public string EncryptString(string stringValue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Text", stringValue);
                parameters.Add("Key", "@");
                var query = "SELECT [dbo].[EncryptString](@Text, @Key)";
                var result = connection.QuerySingle<String>(sql: query, param: parameters, commandType: CommandType.Text);

                return result;
            }
        }

        public string DecryptString(string stringValue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Text", stringValue);
                parameters.Add("Key", "@");
                var query = "SELECT [dbo].[DecryptString](@Text, @Key)";
                var result = connection.QuerySingle<String>(sql: query, param: parameters, commandType: CommandType.Text);

                return result;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<string> EncryptStringAsync(string stringValue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Text", stringValue);
                parameters.Add("Key", "@");
                var query = "SELECT [dbo].[EncryptString](@Text, @Key)";
                var result = await connection.QuerySingleAsync<String>(sql: query, param: parameters, commandType: CommandType.Text);

                return result;
            }
        }

        public async Task<string> DecryptStringAsync(string stringValue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Text", stringValue);
                parameters.Add("Key", "@");
                var query = "SELECT [dbo].[DecryptString](@Text, @Key)";
                var result = await connection.QuerySingleAsync<String>(sql: query, param: parameters, commandType: CommandType.Text);

                return result;
            }
        }

        #endregion

    }

}
