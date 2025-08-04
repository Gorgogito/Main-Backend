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
    public class AccessControlController : Controller
    {
        private readonly IAccessControlApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string Method = string.Empty;

        public AccessControlController(IAccessControlApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("AccessControlRegister")]
        public IActionResult AccessControlRegister([FromBody] RequestDtoAccessControl_Insert requestDto)
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

        [HttpPut("AccessControlActualice")]
        public IActionResult AccessControlActualice([FromBody] RequestDtoAccessControl_Update requestDto)
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

        [HttpDelete("AccessControlDelete")]
        public IActionResult AccessControlDelete([FromBody] RequestDtoAccessControl_Delete requestDto)
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

        [HttpPatch("AccessControlGetById")]
        public IActionResult AccessControlGetById([FromBody] RequestDtoAccessControl_GetById requestDto)
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

        [HttpPatch("AccessControlGetByResource")]
        public IActionResult AccessControlGetByResource([FromBody] RequestDtoAccessControl_GetByResource requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetByResource(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AccessControlGetByProgram")]
        public IActionResult AccessControlGetByProgram([FromBody] RequestDtoAccessControl_GetByProgram requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetByProgram(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("AccessControlList")]
        public IActionResult AccessControlList()
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

        [HttpPatch("AccessControlListWithPagination")]
        public IActionResult AccessControlListWithPagination([FromBody] RequestDtoAccessControl_ListWithPagination requestDto)
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

        #region "Métodos Asincronos"

        [HttpPost("AccessControlRegisterAsync")]
        public async Task<IActionResult> AccessControlRegisterAsync([FromBody] RequestDtoAccessControl_Insert requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.InsertAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("AccessControlActualiceAsync")]
        public async Task<IActionResult> AccessControlActualiceAsync([FromBody] RequestDtoAccessControl_Update requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.UpdateAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("AccessControlDeleteAsync")]
        public async Task<IActionResult> AccessControlDeleteAsync([FromBody] RequestDtoAccessControl_Delete requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.DeleteAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AccessControlGetByIdAsync")]
        public async Task<IActionResult> AccessControlGetByIdAsync([FromBody] RequestDtoAccessControl_GetById requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.GetByIdAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AccessControlGetByResourceAsync")]
        public async Task<IActionResult> AccessControlGetByResourceAsync([FromBody] RequestDtoAccessControl_GetByResource requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.GetByResourceAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AccessControlGetByProgramAsync")]
        public async Task<IActionResult> AccessControlGetByProgramAsync([FromBody] RequestDtoAccessControl_GetByProgram requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.GetByProgramAsync(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("AccessControlListAsync")]
        public async Task<IActionResult> AccessControlListAsync()
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            var response = await _entityApplication.ListAsync();
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AccessControlListWithPaginationAsync")]
        public async Task<IActionResult> AccessControlListWithPaginationAsync([FromBody] RequestDtoAccessControl_ListWithPagination requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = await _entityApplication.ListWithPaginationAsync(requestDto);
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
