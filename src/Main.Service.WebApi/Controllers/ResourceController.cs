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
    public class ResourceController : Controller
    {

        private readonly IResourceApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string Method = string.Empty;

        public ResourceController(IResourceApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("ResourceRegister")]
        public IActionResult ResourceRegister([FromBody] RequestDtoResource_Insert requestDto)
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

        [HttpPut("ResourceActualice")]
        public IActionResult ResourceActualice([FromBody] RequestDtoResource_Update requestDto)
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

        [HttpDelete("ResourceDelete")]
        public IActionResult ResourceDelete([FromBody] RequestDtoResource_Delete requestDto)
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

        [HttpPatch("ResourceGetById")]
        public IActionResult ResourceGetById([FromBody] RequestDtoResource_GetById requestDto)
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

        [HttpGet("ResourceList")]
        public IActionResult ResourceList()
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

        [HttpPatch("ResourceListWithPagination")]
        public IActionResult ResourceListWithPagination([FromBody] RequestDtoResource_ListWithPagination requestDto)
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
