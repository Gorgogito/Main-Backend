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
    public class ResourceApplication: IResourceApplication
    {

        #region Variables Privadas

        private readonly IResourceDomain _entDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ResourceDto_Insert_Validator _insertDtoValidator;
        private readonly ResourceDto_Update_Validator _updateDtoValidator;
        private readonly ResourceDto_Delete_Validator _deleteDtoValidator;
        private readonly ResourceDto_GetById_Validator _getByIdDtoValidator;
        private readonly ResourceDto_ListWithPagination_Validator _withPaginatioDtoValidator;

        private string Method = string.Empty;

        #endregion

        #region Constructor

        public ResourceApplication
        (
         IResourceDomain entDomain,
         IMapper mapper,
         ILogger logger,
         ResourceDto_Insert_Validator insertDtoValidator,
         ResourceDto_Update_Validator updateDtoValidator,
         ResourceDto_Delete_Validator deleteDtoValidator,
         ResourceDto_GetById_Validator getByIdDtoValidator,
         ResourceDto_ListWithPagination_Validator withPaginatioDtoValidator
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
        }

        #endregion

        #region Métodos Síncronos

        public Response<bool> Insert(RequestDtoResource_Insert request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _insertDtoValidator.Validate(new RequestDtoResource_Insert()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
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
                var customer = _mapper.Map<Resource>(request);
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

        public Response<bool> Update(RequestDtoResource_Update request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _updateDtoValidator.Validate(new RequestDtoResource_Update()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
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
                var exist = new NotRecords<Resource?>(_entDomain.GetById(request.Code!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                var customer = _mapper.Map<Resource>(request);
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

        public Response<bool> Delete(RequestDtoResource_Delete request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<bool>();

            var validation = _deleteDtoValidator.Validate(new RequestDtoResource_Delete()
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
                var exist = new NotRecords<Resource?>(_entDomain.GetById(request.Code!));
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

        public Response<ResponseDtoResource> GetById(RequestDtoResource_GetById request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<ResponseDtoResource>();

            var validation = _getByIdDtoValidator.Validate(new RequestDtoResource_GetById()
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
                var exist = new NotRecords<Resource?>(_entDomain.GetById(request.Code!));
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, exist.Response.Errors);
                    return response;
                }

                response.Data = _mapper.Map<ResponseDtoResource>(exist.Record);

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

        public Response<IEnumerable<ResponseDtoResource>> List()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoResource>>();
            try
            {
                var entity = _entDomain.List();
                response.Data = _mapper.Map<IEnumerable<ResponseDtoResource>>(entity);
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

        public Response<IEnumerable<ResponseDtoResource>> ListWithPagination(RequestDtoResource_ListWithPagination request)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            var response = new Response<IEnumerable<ResponseDtoResource>>();

            var validation = _withPaginatioDtoValidator.Validate(new RequestDtoResource_ListWithPagination()
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
                response.Data = _mapper.Map<IEnumerable<ResponseDtoResource>>(req);

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
