using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;

namespace Main.Infrastructure.Repository
{
    public class ProgramRepository: IProgramRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private string Method = string.Empty;

        public ProgramRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(Program entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@CodeMenu", entity.CodeMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@PathProgram", entity.PathProgram);
                    parameters.Add("@PathImage", entity.PathImage);
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

        public bool Update(Program entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@CodeMenu", entity.CodeMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@PathProgram", entity.PathProgram);
                    parameters.Add("@PathImage", entity.PathImage);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return false;
            }
        }

        public bool Delete(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
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

        public Program? GetById(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Program? entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[ProgramGetByID]";
                    entity = connection.QuerySingle<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Program>? GetByGroupMenu(string codeGroupMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeGroupMenu", codeGroupMenu);
                    var query = "[dbo].[ProgramGetByGroupMenu]";
                    var entity = connection.Query<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Program>? GetByMenu(string codeMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeMenu", codeMenu);
                    var query = "[dbo].[ProgramGetByMenu]";
                    var entity = connection.Query<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Program>? List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramList]";
                    var entity = connection.Query<Program>(query, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Program>? ListWithPagination(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Program entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@CodeMenu", entity.CodeMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@PathProgram", entity.PathProgram);
                    parameters.Add("@PathImage", entity.PathImage);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> UpdateAsync(Program entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@CodeMenu", entity.CodeMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@PathProgram", entity.PathProgram);
                    parameters.Add("@PathImage", entity.PathImage);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<Program?> GetByIdAsync(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Program? entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[ProgramGetByID]";
                    entity = await connection.QuerySingleAsync<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Program>?> GetByGroupMenuAsync(string codeGroupMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeGroupMenu", codeGroupMenu);
                    var query = "[dbo].[ProgramGetByGroupMenu]";
                    var entity = await connection.QueryAsync<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Program>?> GetByMenuAsync(string codeMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeMenu", codeMenu);
                    var query = "[dbo].[ProgramGetByMenu]";
                    var entity = await connection.QueryAsync<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Program>?> ListAsync()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramList]";
                    var entity = await connection.QueryAsync<Program>(query, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<Program>?> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ProgramListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = await connection.QueryAsync<Program>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
