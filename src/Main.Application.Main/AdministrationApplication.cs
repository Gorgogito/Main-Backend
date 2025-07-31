using AutoMapper;
using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Application.Interface;
using Main.Application.Validator;
using Main.Cross.Common;
using Main.Domain.Entity.Resource;
using Main.Domain.Interface;
using Solutions.Utility.AppLogger;
using System.Reflection;

namespace Main.Application.Main
{
    public class AdministrationApplication : IAdministrationApplication
    {

        #region Variables Privadas

        private readonly IAdministrationDomain _entDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly AdministrationDto_Insert_Validator _insertDtoValidator;
        private readonly AdministrationDto_Update_Validator _updateDtoValidator;
        private readonly AdministrationDto_Delete_Validator _deleteDtoValidator;
        private readonly AdministrationDto_GetById_Validator _getByIdDtoValidator;
        private readonly AdministrationDto_GetByResource_Validator _getByResourceDtoValidator;
        private readonly AdministrationDto_GetByRole_Validator _getByRoleDtoValidator;
        private readonly AdministrationDto_ListWithPagination_Validator _withPaginatioDtoValidator;

        #endregion

        #region Constructor

        public AdministrationApplication
        (
         IAdministrationDomain entDomain,
         IMapper mapper,
         ILogger logger,
         AdministrationDto_Insert_Validator insertDtoValidator,
         AdministrationDto_Update_Validator updateDtoValidator,
         AdministrationDto_Delete_Validator deleteDtoValidator,
         AdministrationDto_GetById_Validator getByIdDtoValidator,
         AdministrationDto_GetByResource_Validator getByResourceDtoValidator,
         AdministrationDto_GetByRole_Validator getByRoleDtoValidator,
         AdministrationDto_ListWithPagination_Validator withPaginatioDtoValidator
        )
        {
            _entDomain = entDomain;
            _mapper = mapper;
            _logger = logger;
            _insertDtoValidator = insertDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _deleteDtoValidator = deleteDtoValidator;
            _getByIdDtoValidator = getByIdDtoValidator;
            _withPaginatioDtoValidator = withPaginatioDtoValidator;
            _getByResourceDtoValidator = getByResourceDtoValidator;
            _getByRoleDtoValidator = getByRoleDtoValidator;
        }

        #endregion

        #region Métodos Síncronos

        public Response<bool> Insert(RequestDtoAdministration_Insert request)
        {
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoAdministration_Insert()
            {
                CodeResource = request.CodeResource,
                CodeRole = request.CodeRole,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy
            }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var ent = _mapper.Map<Administration>(request);
                response.Data = _entDomain.Insert(ent);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Registro Exitoso!!!");
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<bool> Update(RequestDtoAdministration_Update request)
        {
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoAdministration_Update()
            {
                CodeResource = request.CodeResource,
                CodeRole = request.CodeRole,
                LastModifiedDate = request.LastModifiedDate,
                LastModifiedBy = request.LastModifiedBy
            }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Administration>(_entDomain.GetById(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                var customer = _mapper.Map<Administration>(request);
                response.Data = _entDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Actualización Exitosa!!!");
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<bool> Delete(RequestDtoAdministration_Delete request)
        {
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoAdministration_Delete()
            { CodeRole = request.CodeRole, CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Administration>(_entDomain.GetById(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _entDomain.Delete(request.CodeRole, request.CodeResource);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Eliminación Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<ResponseDtoAdministration> GetById(RequestDtoAdministration_GetById request)
        {
            var response = new Response<ResponseDtoAdministration>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoAdministration_GetById()
            { CodeRole = request.CodeRole, CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Administration>(_entDomain.GetById(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoAdministration>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoAdministration>> GetByRole(RequestDtoAdministration_GetByRole request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _getByRoleDtoValidator.Validate(new RequestDtoAdministration_GetByRole()
            { CodeRole = request.CodeRole });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Administration>>(_entDomain.GetByRole(request.CodeRole));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoAdministration>> GetByResource(RequestDtoAdministration_GetByResource request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _getByResourceDtoValidator.Validate(new RequestDtoAdministration_GetByResource()
            { CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Administration>>(_entDomain.GetByResource(request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoAdministration>> List()
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();
            try
            {
                var entity = _entDomain.List();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public Response<IEnumerable<ResponseDtoAdministration>> ListWithPagination(RequestDtoAdministration_ListWithPagination request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoAdministration_ListWithPagination()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var req = _entDomain.ListWithPagination(request.PageNumber, request.PageSize);
                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(req);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(RequestDtoAdministration_Insert request)
        {
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoAdministration_Insert()
            {
                CodeResource = request.CodeResource,
                CodeRole = request.CodeRole,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy
            }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var entity = _mapper.Map<Administration>(request);
                response.Data = await _entDomain.InsertAsync(entity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Registro Exitoso!!!");
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(RequestDtoAdministration_Update request)
        {
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoAdministration_Update()
            {
                CodeResource = request.CodeResource,
                CodeRole = request.CodeRole,
                LastModifiedDate = request.LastModifiedDate,
                LastModifiedBy = request.LastModifiedBy
            }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {

                var exist = new NotRecords<Administration>(_entDomain.GetById(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                var entity = _mapper.Map<Administration>(request);
                response.Data = await _entDomain.UpdateAsync(entity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Actualización Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(RequestDtoAdministration_Delete request)
        {
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoAdministration_Delete()
            { CodeRole = request.CodeRole, CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Administration>(_entDomain.GetById(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = await _entDomain.DeleteAsync(request.CodeRole, request.CodeResource);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Eliminación Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<ResponseDtoAdministration>> GetByIdAsync(RequestDtoAdministration_GetById request)
        {
            var response = new Response<ResponseDtoAdministration>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoAdministration_GetById()
            { CodeRole = request.CodeRole, CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Administration>(await _entDomain.GetByIdAsync(request.CodeRole, request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoAdministration>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<ResponseDtoAdministration>>> GetByRoleAsync(RequestDtoAdministration_GetByRole request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _getByRoleDtoValidator.Validate(new RequestDtoAdministration_GetByRole()
            { CodeRole = request.CodeRole });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Administration>>(await _entDomain.GetByResourceAsync(request.CodeRole));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<ResponseDtoAdministration>>> GetByResourceAsync(RequestDtoAdministration_GetByResource request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _getByResourceDtoValidator.Validate(new RequestDtoAdministration_GetByResource()
            { CodeResource = request.CodeResource });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Administration>>(await _entDomain.GetByResourceAsync(request.CodeResource));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<ResponseDtoAdministration>>> ListAsync()
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();
            try
            {
                var entity = await _entDomain.ListAsync();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<ResponseDtoAdministration>>> ListWithPaginationAsync(RequestDtoAdministration_ListWithPagination request)
        {
            var response = new Response<IEnumerable<ResponseDtoAdministration>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoAdministration_ListWithPagination()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }

            try
            {
                var req = await _entDomain.ListWithPaginationAsync(request.PageNumber, request.PageSize);
                response.Data = _mapper.Map<IEnumerable<ResponseDtoAdministration>>(req);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

        #endregion

    }
}