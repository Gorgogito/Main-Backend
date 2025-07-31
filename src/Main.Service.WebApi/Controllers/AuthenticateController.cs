using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Application.Interface;
using Main.Cross.Common;
using Main.Service.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Solutions.Utility.AppLogger;

namespace Main.Service.WebApi.Controllers
{

    [Authorize]
    [Route("api/identy/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        
        private readonly IAuthenticateApplication _authenticateApplication;
        private readonly AppSettings _appSettings;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string _minutes;

        public AuthenticateController(IAuthenticateApplication authApplication, IConfiguration configuration, Solutions.Utility.AppLogger.ILogger logger)
        {
            var appSettingsSection = configuration.GetSection("Config");

            _minutes = appSettingsSection.GetSection("MinutesExpires").Value;
           
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            _authenticateApplication = authApplication;
            _appSettings = appSettings;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] RequestDtoLogin loginDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            var response = _authenticateApplication.Authenticate(loginDto.UserName, loginDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    response.Data.MinutesExpires = Convert.ToInt32(_minutes);
                    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                    return Ok(response);
                }
                else
                {
                    _logger.ErrorFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, response.Errors.ToString());
                    return NotFound(response); 
                }
            }

            return BadRequest(response);
        }

        private string BuildToken(Response<ResponseDtoAuthenticate> authenticateDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                { new Claim(ClaimTypes.Name, authenticateDto.Data.UserName) }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_minutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            SecurityToken token;
            token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }
}
