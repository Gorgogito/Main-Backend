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
    public class ProgramApplication: IProgramApplication
    {

        #region Variables Privadas

        private readonly IProgramDomain _entDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ProgramDto_Insert_Validator _insertDtoValidator;
        private readonly ProgramDto_Update_Validator _updateDtoValidator;
        private readonly ProgramDto_Delete_Validator _deleteDtoValidator;
        private readonly ProgramDto_GetById_Validator _getByIdDtoValidator;
        private readonly ProgramDto_GetByGroupMenu_Validator _getByGroupMenuDtoValidator;
        private readonly ProgramDto_GetByMenu_Validator _getByMenuDtoValidator;
        private readonly ProgramDto_ListWithPagination_Validator _withPaginatioDtoValidator;

        private string Method = string.Empty;

        #endregion

        #region Constructor

        public ProgramApplication
        (
         IProgramDomain entDomain,
         IMapper mapper,
         ILogger logger,
         ProgramDto_Insert_Validator insertDtoValidator,
         ProgramDto_Update_Validator updateDtoValidator,
         ProgramDto_Delete_Validator deleteDtoValidator,
         ProgramDto_GetById_Validator getByIdDtoValidator,
         ProgramDto_GetByGroupMenu_Validator getByGroupMenuDtoValidator,
         ProgramDto_GetByMenu_Validator getByMenuDtoValidator,
         ProgramDto_ListWithPagination_Validator withPaginatioDtoValidator
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
            _getByMenuDtoValidator = getByMenuDtoValidator;
        }

        #endregion

        #region Métodos Síncronos

        public Response<bool> Insert(RequestDtoProgram_Insert request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoProgram_Insert()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                CodeMenu= request.CodeMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                PathProgram = request.PathProgram,
                PathImage= request.PathImage,
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
                var customer = _mapper.Map<Program>(request);
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

        public Response<bool> Update(RequestDtoProgram_Update request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoProgram_Update()
            {
                Code = request.Code,
                CodeGroupMenu = request.CodeGroupMenu,
                CodeMenu = request.CodeMenu,
                Name = request.Name,
                Description = request.Description,
                Order = request.Order,
                PathProgram = request.PathProgram,
                PathImage = request.PathImage,
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
                var exist = new NotRecords<Program?>(_entDomain.GetById(request.Code!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                var customer = _mapper.Map<Program>(request);
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

        public Response<bool> Delete(RequestDtoProgram_Delete request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoProgram_Delete()
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
                var exist = new NotRecords<Program?>(_entDomain.GetById(request.Code!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _entDomain.Delete(request.Code!);
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

        public Response<ResponseDtoProgram> GetById(RequestDtoProgram_GetById request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<ResponseDtoProgram>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoProgram_GetById()
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
                var exist = new NotRecords<Program?>(_entDomain.GetById(request.Code!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoProgram>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoProgram>> GetByGroupMenu(RequestDtoProgram_GetByGroupMenu request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoProgram>>();

            var validation = _getByGroupMenuDtoValidator.Validate(new RequestDtoProgram_GetByGroupMenu()
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
                var exist = new NotRecords<IEnumerable<Program>?>(_entDomain.GetByGroupMenu(request.CodeGroupMenu!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoProgram>>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoProgram>> GetByMenu(RequestDtoProgram_GetByMenu request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoProgram>>();

            var validation = _getByMenuDtoValidator.Validate(new RequestDtoProgram_GetByMenu()
            { CodeMenu = request.CodeMenu });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, validation.Errors);
                return response;
            }

            try
            {
                var exist = new NotRecords<IEnumerable<Program>?>(_entDomain.GetByMenu(request.CodeMenu!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<ResponseDtoProgram>>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoProgram>> List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoProgram>>();
            try
            {
                var entity = _entDomain.List();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoProgram>>(entity);
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

        public Response<IEnumerable<ResponseDtoProgram>> ListWithPagination(RequestDtoProgram_ListWithPagination request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoProgram>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoProgram_ListWithPagination()
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
                response.Data = _mapper.Map<IEnumerable<ResponseDtoProgram>>(req);

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
