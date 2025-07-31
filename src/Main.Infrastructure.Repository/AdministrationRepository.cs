using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using System.Data;
using System.Reflection;
using Solutions.Utility.AppLogger;

namespace Main.Infrastructure.Repository
{
    public class AdministrationRepository: IAdministrationRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;

        public AdministrationRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(Administration entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", entity.CodeRole);
                    parameters.Add("@CodeResource", entity.CodeResource);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
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

        public bool Update(Administration entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", entity.CodeRole);
                    parameters.Add("@CodeResource", entity.CodeResource);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
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

        public bool Delete(string codeRole, string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    parameters.Add("@CodeResource", codeResource);
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

        public Administration GetById(string codeRole, string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Administration entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    parameters.Add("@CodeResource", codeResource);
                    var query = "[dbo].[AdministrationGetByID]";
                    entity = connection.QuerySingle<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Administration> GetByResource(string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeResource", codeResource);
                    var query = "[dbo].[AdministrationGetByResource]";
                    var entity = connection.Query<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Administration> GetByRole(string codeRole)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    var query = "[dbo].[AdministrationGetByRole]";
                    var entity = connection.Query<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Administration> List()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationList]";
                    var entity = connection.Query<Administration>(query, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Administration> ListWithPagination(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Administration entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", entity.CodeRole);
                    parameters.Add("@CodeResource", entity.CodeResource);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
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

        public async Task<bool> UpdateAsync(Administration entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", entity.CodeRole);
                    parameters.Add("@CodeResource", entity.CodeResource);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
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

        public async Task<bool> DeleteAsync(string codeRole, string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    parameters.Add("@CodeResource", codeResource);
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

        public async Task<Administration> GetByIdAsync(string codeRole, string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Administration entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", codeRole);
                    parameters.Add("@CodeResource", codeResource);
                    var query = "[dbo].[AdministrationGetByID]";
                    entity = await connection.QuerySingleAsync<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Administration>> GetByResourceAsync(string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeResource", codeResource);
                    var query = "[dbo].[AdministrationGetByResource]";
                    var entity = await connection.QueryAsync<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Administration>> GetByRoleAsync(string CodeRole)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeRole", CodeRole);
                    var query = "[dbo].[AdministrationGetByRole]";
                    var entity = await connection.QueryAsync<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Administration>> ListAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationList]";
                    var entity = await connection.QueryAsync<Administration>(query, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Administration>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AdministrationListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = await connection.QueryAsync<Administration>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
