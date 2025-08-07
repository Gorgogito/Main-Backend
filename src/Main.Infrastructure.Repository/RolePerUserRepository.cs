using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Infrastructure.Interface;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Main.Infrastructure.Repository
{
    public class RolePerUserRepository: IRolePerUserRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private string Method = string.Empty;

        public RolePerUserRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(RolePerUser entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RolePerUserInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserName", entity.UserName);
                    parameters.Add("@CodeRole", entity.CodeRole);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Registro Exitoso!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return false;
            }
        }

        public bool Delete(string userName, string codeRole)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RolePerUserDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserName", userName);
                    parameters.Add("@CodeRole", codeRole);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Eliminación Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return false;
            }
        }

        public RolePerUser? GetById(string userName, string codeRole)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    RolePerUser? entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserName", userName);
                    parameters.Add("@CodeRole", codeRole);
                    var query = "[dbo].[RolePerUserGetByID]";
                    entity = connection.QuerySingle<RolePerUser>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return null;
            }
        }

        public IEnumerable<RolePerUser>? GetByUser(string userName)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserName", userName);
                    var query = "[dbo].[RolePerUserGetByUser]";
                    var entity = connection.Query<RolePerUser>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return null;
            }
        }

        public IEnumerable<RolePerUser>? GetByRole(string codeRole)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    var query = "[dbo].[RolePerUserGetByRole]";
                    var entity = connection.Query<RolePerUser>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return null;
            }
        }

        public IEnumerable<RolePerUser>? List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RolePerUserList]";
                    var entity = connection.Query<RolePerUser>(query, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return null;
            }
        }

        public IEnumerable<RolePerUser>? ListWithPagination(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RolePerUserListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<RolePerUser>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return null;
            }
        }

        #endregion

    }
}
