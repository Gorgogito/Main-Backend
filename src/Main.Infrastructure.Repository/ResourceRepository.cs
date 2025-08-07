using Dapper;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Main.Infrastructure.Interface;
using Solutions.Utility.AppLogger;
using System.Data;
using System.Reflection;

namespace Main.Infrastructure.Repository
{
    public class ResourceRepository: IResourceRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private string Method = string.Empty;

        public ResourceRepository(IConnectionFactory connectionFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        #region Métodos Síncronos        

        public bool Insert(Resource entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ResourceInsert]";
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

        public bool Update(Resource entity)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ResourceUpdate]";
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
                    var query = "[dbo].[ResourceDelete]";
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

        public Resource? GetById(string code)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    Resource? entity = null;
                    var parameters = new DynamicParameters();
                    parameters.Add("@Code", code);
                    var query = "[dbo].[ResourceGetByID]";
                    entity = connection.QuerySingle<Resource>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Resource>? List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ResourceList]";
                    var entity = connection.Query<Resource>(query, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<Resource>? ListWithPagination(int pageNumber, int pageSize)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "[dbo].[ResourceListWithPagination]";
                    var parameters = new DynamicParameters();
                    parameters.Add("PageNumber", pageNumber);
                    parameters.Add("PageSize", pageSize);
                    var entity = connection.Query<Resource>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
