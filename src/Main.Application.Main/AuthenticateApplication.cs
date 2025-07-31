using AutoMapper;
using Main.Application.DTO.Response;
using Main.Application.Interface;
using Main.Application.Validator;
using Main.Cross.Common;
using Main.Domain.Entity.Identy;
using Main.Domain.Interface;
using System.Reflection;
using Solutions.Utility.AppLogger;

namespace Main.Application.Main
{
    public class AuthenticateApplication : IAuthenticateApplication
    {

        private readonly IAuthenticateDomain _authenticateDomain;
        private readonly IMapper _mapper;
        private readonly AuthenticateDtoValidator _authenticateDtoValidator;
        private readonly ILogger _logger;

        public AuthenticateApplication(IAuthenticateDomain authenticateDomain, IMapper mapper, ILogger logger, AuthenticateDtoValidator authenticateDtoValidator)
        {
            _authenticateDomain = authenticateDomain;
            _mapper = mapper;
            _authenticateDtoValidator = authenticateDtoValidator;
            _logger = logger;
        }

        public Response<ResponseDtoAuthenticate> Authenticate(string username, string password)
        {
            var response = new Response<ResponseDtoAuthenticate>();
            var validation = _authenticateDtoValidator.Validate(new ResponseDtoAuthenticate() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, validation.Errors);
                return response;
            }
            try
            {

                var exist = new NotRecords<Authenticate>(_authenticateDomain.Authenticate(username, password), true);
                if (!exist.Success)
                {
                    response.Message = exist.Response.Message;
                    response.Errors = exist.Response.Errors;
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exist.Response.Errors);
                    return response;
                }
                response.Data = _mapper.Map<ResponseDtoAuthenticate>(exist.Record);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Consulta Exitosa!!!");
                }

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario o Contraseña incorrecta.";
                _logger.WarnFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Usuario o Contraseña incorrecta.");
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, e.Message);
            }
            return response;
        }

    }
}