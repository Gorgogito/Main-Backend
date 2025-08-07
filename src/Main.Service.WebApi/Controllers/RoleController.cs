using Main.Application.DTO.Request;
using Main.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Main.Service.WebApi.Controllers
{

    [Authorize]
    [Route("api/resource/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {

        private readonly IRoleApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string Method = string.Empty;

        public RoleController(IRoleApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("RoleRegister")]
        public IActionResult RoleRegister([FromBody] RequestDtoRole_Insert requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Insert(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("RoleActualice")]
        public IActionResult RoleActualice([FromBody] RequestDtoRole_Update requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Update(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("RoleDelete")]
        public IActionResult RoleDelete([FromBody] RequestDtoRole_Delete requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Delete(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("RoleGetById")]
        public IActionResult RoleGetById([FromBody] RequestDtoRole_GetById requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetById(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("RoleList")]
        public IActionResult RoleList()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            var response = _entityApplication.List();
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("RoleListWithPagination")]
        public IActionResult RoleListWithPagination([FromBody] RequestDtoRole_ListWithPagination requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.ListWithPagination(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        #endregion

    }
}
