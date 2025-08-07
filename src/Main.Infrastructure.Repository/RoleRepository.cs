using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;

namespace Main.Infrastructure.Repository
{
    public class RoleRepository: IRoleRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private string Method = string.Empty;

        public RoleRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(Role entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RoleInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
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

        public bool Update(Role entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RoleUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@Name", entity.Name);
                    parameters.Add("@Description", entity.Description);
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
                    var query = "[dbo].[RoleDelete]";
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

        public Role? GetById(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Role? entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[RoleGetByID]";
                    entity = connection.QuerySingle<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Role>? List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RoleList]";
                    var entity = connection.Query<Role>(query, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Role>? ListWithPagination(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[RoleListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
