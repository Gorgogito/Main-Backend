using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Infrastructure.Interface;
using System.Data;
using System.Reflection;
using Solutions.Utility.AppLogger;

namespace Main.Infrastructure.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;

        public AuthenticateRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public Authenticate Authenticate(string userName, string password)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Authenticate user = new Domain.Entity.Identy.Authenticate();

                    var parameters = new DynamicParameters();

                    parameters.Add("UserName", userName);
                    parameters.Add("Password", password);

                    var query = "[dbo].[UserGetByUserAndPassword]";

                    user = connection.QuerySingle<Authenticate>(query, param: parameters, commandType: CommandType.StoredProcedure);

                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");

                    return user;
                }
            }
            catch (Exception e)
            {               
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

    }
}
