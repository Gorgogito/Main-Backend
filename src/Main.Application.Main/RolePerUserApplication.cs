using AutoMapper;
using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Application.Interface;
using Main.Application.Validator;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Domain.Interface;
using Solutions.Utility.AppLogger;
using System.Reflection;

namespace Main.Application.Main
{
    public class RolePerUserApplication : IRolePerUserApplication
    {

        #region Variables Privadas

        private readonly IRolePerUserDomain _entDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly RolePerUserDto_Insert_Validator _insertDtoValidator;
        private readonly RolePerUserDto_Delete_Validator _deleteDtoValidator;
        private readonly RolePerUserDto_GetById_Validator _getByIdDtoValidator;
        private readonly RolePerUserDto_GetByUser_Validator _getByUserDtoValidator;
        private readonly RolePerUserDto_GetByRole_Validator _getByRoleDtoValidator;
        private readonly RolePerUserDto_ListWithPagination_Validator _withPaginatioDtoValidator;

        private string Method = string.Empty;

        #endregion

        #region Constructor

        public RolePerUserApplication
        (
         IRolePerUserDomain entDomain,
         IMapper mapper,
         ILogger logger,
         RolePerUserDto_Insert_Validator insertDtoValidator,         
         RolePerUserDto_Delete_Validator deleteDtoValidator,
         RolePerUserDto_GetById_Validator getByIdDtoValidator,
         RolePerUserDto_GetByUser_Validator getByUserDtoValidator,
         RolePerUserDto_GetByRole_Validator getByRoleDtoValidator,
         RolePerUserDto_ListWithPagination_Validator withPaginatioDtoValidator
        )
        {
            _entDomain = entDomain;
            _mapper = mapper;
            _logger = logger;
            _insertDtoValidator = insertDtoValidator;
            _deleteDtoValidator = deleteDtoValidator;
            _getByIdDtoValidator = getByIdDtoValidator;
            _getByUserDtoValidator = getByUserDtoValidator;
            _getByRoleDtoValidator = getByRoleDtoValidator;
            _withPaginatioDtoValidator = withPaginatioDtoValidator;
        }

        #endregion

        #region Métodos Síncronos

        public Response<bool> Insert(RequestDtoRolePerUser_Insert request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoRolePerUser_Insert()
            {
                UserName = request.UserName,
                CodeRole = request.CodeRole,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy
            }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var customer = _mapper.Map<RolePerUser>(request);
                response.Data = _entDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Registro Exitoso!!!");
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<bool> Delete(RequestDtoRolePerUser_Delete request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoRolePerUser_Delete()
            { UserName = request.UserName, CodeRole = request.CodeRole });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<RolePerUser?>(_entDomain.GetById(request.UserName!, request.CodeRole!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _entDomain.Delete(request.UserName!, request.CodeRole!);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Eliminación Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<ResponseDtoRolePerUser> GetById(RequestDtoRolePerUser_GetById request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<ResponseDtoRolePerUser>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoRolePerUser_GetById()
            { UserName = request.UserName, CodeRole = request.CodeRole });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<RolePerUser?>(_entDomain.GetById(request.UserName!, request.CodeRole!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoRolePerUser>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoRolePerUser>>? GetByUser(RequestDtoRolePerUser_GetByUser request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoRolePerUser>>();

            var validation = _getByUserDtoValidator.Validate(new RequestDtoRolePerUser_GetByUser()
            { UserName = request.UserName });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<RolePerUser>?>(_entDomain.GetByUser(request.UserName!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoRolePerUser>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoRolePerUser>>? GetByRole(RequestDtoRolePerUser_GetByRole request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoRolePerUser>>();

            var validation = _getByRoleDtoValidator.Validate(new RequestDtoRolePerUser_GetByRole()
            {  CodeRole = request.CodeRole });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<RolePerUser>?>(_entDomain.GetByRole(request.CodeRole!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoRolePerUser>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoRolePerUser>> List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoRolePerUser>>();
            try
            {
                var entity = _entDomain.List();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoRolePerUser>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoRolePerUser>> ListWithPagination(RequestDtoRolePerUser_ListWithPagination request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoRolePerUser>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoRolePerUser_ListWithPagination()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var req = _entDomain.ListWithPagination(request.PageNumber, request.PageSize);
                response.Data = _mapper.Map<IEnumerable<ResponseDtoRolePerUser>>(req);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        #endregion

    }
}
