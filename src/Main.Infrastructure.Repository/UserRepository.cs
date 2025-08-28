using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Infrastructure.Interface;
using System.Data;
using System.Reflection;
using Solutions.Utility.AppLogger;

namespace Main.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;

        public UserRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(User entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", entity.UserName);
                    parameters.Add("Password", entity.Password);
                    parameters.Add("Description", entity.Description);
                    parameters.Add("Names", entity.Names);
                    parameters.Add("Surnames", entity.Surnames);
                    parameters.Add("Phone", entity.Phone);
                    parameters.Add("EMail", entity.EMail);
                    parameters.Add("CreatedDate", entity.CreatedDate);
                    parameters.Add("CreatedBy", entity.CreatedBy);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Registro Exitoso!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public bool Update(User entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", entity.UserName);
                    parameters.Add("Password", entity.Password);
                    parameters.Add("Description", entity.Description);
                    parameters.Add("Names", entity.Names);
                    parameters.Add("Surnames", entity.Surnames);
                    parameters.Add("Phone", entity.Phone);
                    parameters.Add("EMail", entity.EMail);
                    parameters.Add("LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("LastModifiedBy", entity.LastModifiedBy);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public bool Delete(string userName)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", userName);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Eliminación Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public User GetById(string userName)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    User entity = null;

                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", userName);

                    var query = "[dbo].[UserGetByID]";

                    entity = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        public IEnumerable<User> List()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserList]";

                    var entity = connection.Query<User>(query, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        public IEnumerable<User> ListWithPagination(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);

                    var entity = connection.Query<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        public bool ResetPassword(User entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserResetPassword]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", entity.UserName);
                    parameters.Add("Password", entity.Password);
                    parameters.Add("LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("LastModifiedBy", entity.LastModifiedBy);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod()!.Name, "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod()!.Name, e.Message);
                return false;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(User entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", entity.UserName);
                    parameters.Add("Password", entity.Password);
                    parameters.Add("Description", entity.Description);
                    parameters.Add("Names", entity.Names);
                    parameters.Add("Surnames", entity.Surnames);
                    parameters.Add("Phone", entity.Phone);
                    parameters.Add("EMail", entity.EMail);
                    parameters.Add("CreatedDate", entity.CreatedDate);
                    parameters.Add("CreatedBy", entity.CreatedBy);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Registro Exitoso!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserName", entity.UserName);
                    parameters.Add("Password", entity.Password);
                    parameters.Add("Description", entity.Description);
                    parameters.Add("Names", entity.Names);
                    parameters.Add("Surnames", entity.Surnames);
                    parameters.Add("Phone", entity.Phone);
                    parameters.Add("EMail", entity.EMail);
                    parameters.Add("CreatedDate", entity.CreatedDate);
                    parameters.Add("CreatedBy", entity.CreatedBy);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string userName)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("userName", userName);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Eliminación Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return false;
            }
        }

        public async Task<User> GetByIdAsync(string userName)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    User entity = null;

                    var parameters = new DynamicParameters();
                    parameters.Add("userName", userName);

                    var query = "[dbo].[UserGetByID]";

                    entity = await connection.QuerySingleAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserList]";

                    var entity = await connection.QueryAsync<User>(query, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[UserListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);

                    var entity = await connection.QueryAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                return null;
            }
        }

        #endregion

    }
}
