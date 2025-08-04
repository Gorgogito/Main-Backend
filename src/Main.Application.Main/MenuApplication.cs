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
    public class MenuApplication : IMenuApplication
    {

        #region Variables Privadas

        private readonly IMenuDomain _entDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly MenuDto_Insert_Validator _insertDtoValidator;
        private readonly MenuDto_Update_Validator _updateDtoValidator;
        private readonly MenuDto_Delete_Validator _deleteDtoValidator;
        private readonly MenuDto_GetById_Validator _getByIdDtoValidator;
        private readonly MenuDto_GetByGroupMenu_Validator _getByGroupMenuDtoValidator;
        private readonly MenuDto_ListWithPagination_Validator _withPaginatioDtoValidator;

        private string Method = string.Empty;

        #endregion

        #region Constructor

        public MenuApplication
        (
         IMenuDomain entDomain,
         IMapper mapper,
         ILogger logger,
         MenuDto_Insert_Validator insertDtoValidator,
         MenuDto_Update_Validator updateDtoValidator,
         MenuDto_Delete_Validator deleteDtoValidator,
         MenuDto_GetById_Validator getByIdDtoValidator,
         MenuDto_GetByGroupMenu_Validator getByGroupMenuDtoValidator,
         MenuDto_ListWithPagination_Validator withPaginatioDtoValidator
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
            _getByGroupMenuDtoValidator = getByGroupMenuDtoValidator;
        }

        #endregion

        #region Métodos Síncronos

        public Response<bool> Insert(RequestDtoMenu_Insert request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoMenu_Insert()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                Level = request.Level,
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
                var customer = _mapper.Map<Menu>(request);
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

        public Response<bool> Update(RequestDtoMenu_Update request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoMenu_Update()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                Level = request.Level,
                LastModifiedDate = request.LastModifiedDate,
                LastModifiedBy = request.LastModifiedBy
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
                var exist = new NotRecords<Menu>(_entDomain.GetById(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                var customer = _mapper.Map<Menu>(request);
                response.Data = _entDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Actualización Exitosa!!!");
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public Response<bool> Delete(RequestDtoMenu_Delete request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoMenu_Delete()
            { Code = request.Code });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Menu>(_entDomain.GetById(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _entDomain.Delete(request.Code);
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

        public Response<ResponseDtoMenu> GetById(RequestDtoMenu_GetById request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<ResponseDtoMenu>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoMenu_GetById()
            { Code = request.Code });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Menu>(_entDomain.GetById(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoMenu>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoMenu>> GetByGroupMenu(RequestDtoMenu_GetByGroupMenu request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoMenu>>();

            var validation = _getByGroupMenuDtoValidator.Validate(new RequestDtoMenu_GetByGroupMenu()
            { CodeGroupMenu = request.CodeGroupMenu });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Menu>>(_entDomain.GetByGroupMenu(request.CodeGroupMenu));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoMenu>> List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoMenu>>();
            try
            {
                var entity = _entDomain.List();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(entity);
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

        public Response<IEnumerable<ResponseDtoMenu>> ListWithPagination(RequestDtoMenu_ListWithPagination request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoMenu>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoMenu_ListWithPagination()
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
                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(req);

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

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(RequestDtoMenu_Insert request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoMenu_Insert()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                Level = request.Level,
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
                var entity = _mapper.Map<Menu>(request);
                response.Data = await _entDomain.InsertAsync(entity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Registro Exitoso!!!");
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(RequestDtoMenu_Update request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoMenu_Update()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                Level = request.Level,
                LastModifiedDate = request.LastModifiedDate,
                LastModifiedBy = request.LastModifiedBy
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

                var exist = new NotRecords<Menu>(_entDomain.GetById(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                var entity = _mapper.Map<Menu>(request);
                response.Data = await _entDomain.UpdateAsync(entity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Actualización Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(RequestDtoMenu_Delete request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoMenu_Delete()
            { Code = request.Code });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Menu>(_entDomain.GetById(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = await _entDomain.DeleteAsync(request.Code);

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

        public async Task<Response<ResponseDtoMenu>> GetByIdAsync(RequestDtoMenu_GetById request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<ResponseDtoMenu>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoMenu_GetById()
            { Code = request.Code });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<Menu>(await _entDomain.GetByIdAsync(request.Code));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoMenu>(exist.Record);

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

        public async Task<Response<IEnumerable<ResponseDtoMenu>>> GetByGroupMenuAsync(RequestDtoMenu_GetByGroupMenu request)
        {

            var response = new Response<IEnumerable<ResponseDtoMenu>>();

            var validation = _getByGroupMenuDtoValidator.Validate(new RequestDtoMenu_GetByGroupMenu()
            { CodeGroupMenu = request.CodeGroupMenu });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Menu>>(await _entDomain.GetByGroupMenuAsync(request.CodeGroupMenu));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(exist.Record);

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

        public async Task<Response<IEnumerable<ResponseDtoMenu>>> ListAsync()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoMenu>>();
            try
            {
                var entity = await _entDomain.ListAsync();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(entity);
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

        public async Task<Response<IEnumerable<ResponseDtoMenu>>> ListWithPaginationAsync(RequestDtoMenu_ListWithPagination request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoMenu>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoMenu_ListWithPagination()
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
                var req = await _entDomain.ListWithPaginationAsync(request.PageNumber, request.PageSize);
                response.Data = _mapper.Map<IEnumerable<ResponseDtoMenu>>(req);

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
