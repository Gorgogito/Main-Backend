using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;

namespace Main.Infrastructure.Repository
{
    public class MenuRepository: IMenuRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private string Method = string.Empty;

        public MenuRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(Menu entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@Level", entity.Level);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Registro Exitoso!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return false;
            }
        }

        public bool Update(Menu entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@Level", entity.Level);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
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
                    var query = "[dbo].[MenuDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Eliminación Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return false;
            }
        }

        public Menu GetById(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Menu entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[MenuGetByID]";
                    entity = connection.QuerySingle<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public IEnumerable<Menu> GetByGroupMenu(string codeGroupMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeGroupMenu", codeGroupMenu);
                    var query = "[dbo].[MenuGetByGroupMenu]";
                    var entity = connection.Query<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public IEnumerable<Menu> List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuList]";
                    var entity = connection.Query<Menu>(query, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public IEnumerable<Menu> ListWithPagination(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Menu entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@Level", entity.Level);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Registro Exitoso!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Menu entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeGroupMenu", entity.CodeGroupMenu);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
                    parameters.Add("@Order", entity.Order);
                    parameters.Add("@Level", entity.Level);
                    parameters.Add("@LastModifiedDate", entity.LastModifiedDate);
                    parameters.Add("@LastModifiedBy", entity.LastModifiedBy);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Actualización Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
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
                    var query = "[dbo].[MenuDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Eliminación Exitosa!!!");
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return false;
            }
        }

        public async Task<Menu> GetByIdAsync(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Menu entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[MenuGetByID]";
                    entity = await connection.QuerySingleAsync<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Menu>> GetByGroupMenuAsync(string codeGroupMenu)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeGroupMenu", codeGroupMenu);
                    var query = "[dbo].[MenuGetByGroupMenu]";
                    var entity = await connection.QueryAsync<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Menu>> ListAsync()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuList]";
                    var entity = await connection.QueryAsync<Menu>(query, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Menu>> ListWithPaginationAsync(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[MenuListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = await connection.QueryAsync<Menu>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , "Consulta Exitosa!!!");
                    return entity;
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method , e.Message);
                return null;
            }
        }

        #endregion

    }
}
