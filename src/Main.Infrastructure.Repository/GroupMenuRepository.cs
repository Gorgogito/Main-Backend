using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;

namespace Main.Infrastructure.Repository
{
    public class GroupMenuRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;

        public GroupMenuRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(GroupMenu entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AccessControlInsert]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeResource", entity.Name);
                    parameters.Add("@CodeProgram", entity.Description);
                    parameters.Add("@Read", entity.Order);
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

        public bool Update(AccessControl entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AccessControlUpdate]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", entity.Code);
                    parameters.Add("@CodeResource", entity.CodeResource);
                    parameters.Add("@CodeProgram", entity.CodeProgram);
                    parameters.Add("@Read", entity.Read);
                    parameters.Add("@Write", entity.Write);
                    parameters.Add("@Create", entity.Create);
                    parameters.Add("@Eliminate", entity.Eliminate);
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

        public bool Delete(string code)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AccessControlDelete]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
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

        public AccessControl GetById(string code)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    AccessControl entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[AccessControlGetByID]";
                    entity = connection.QuerySingle<AccessControl>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<AccessControl> GetByResource(string codeResource)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeResource", codeResource);
                    var query = "[dbo].[AccessControlGetByResource]";
                    var entity = connection.Query<AccessControl>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<AccessControl> GetByProgram(string codeProgram)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CodeProgram", codeProgram);
                    var query = "[dbo].[AccessControlGetByProgram]";
                    var entity = connection.Query<AccessControl>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<AccessControl> List()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AccessControlList]";
                    var entity = connection.Query<AccessControl>(query, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<AccessControl> ListWithPagination(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[AccessControlListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<AccessControl>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
