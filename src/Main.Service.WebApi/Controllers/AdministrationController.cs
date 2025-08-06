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
    public class AdministrationController : Controller
    {

        private readonly IAdministrationApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        public AdministrationController(IAdministrationApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("AdministrationRegister")]
        public IActionResult AdministrationRegister([FromBody] RequestDtoAdministration_Insert requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Insert(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("AdministrationActualice")]
        public IActionResult AdministrationActualice([FromBody] RequestDtoAdministration_Update requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Update(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("AdministrationDelete")]
        public IActionResult AdministrationDelete([FromBody] RequestDtoAdministration_Delete requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.Delete(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AdministrationGetById")]
        public IActionResult AdministrationGetById([FromBody] RequestDtoAdministration_GetById requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetById(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AdministrationGetByResource")]
        public IActionResult AdministrationGetByResource([FromBody] RequestDtoAdministration_GetByResource requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetByResource(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AdministrationGetByRole")]
        public IActionResult AdministrationGetByRole([FromBody] RequestDtoAdministration_GetByRole requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetByRole(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("AdministrationList")]
        public IActionResult AdministrationList()
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            var response = _entityApplication.List();
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPatch("AdministrationListWithPagination")]
        public IActionResult AdministrationListWithPagination([FromBody] RequestDtoAdministration_ListWithPagination requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.ListWithPagination(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        #endregion

        #region "Métodos Asincronos"

        //[HttpPost("AdministrationRegisterAsync")]
        //public async Task<IActionResult> AdministrationRegisterAsync([FromBody] RequestDtoAdministration_Insert requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.InsertAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPut("AdministrationActualiceAsync")]
        //public async Task<IActionResult> AdministrationActualiceAsync([FromBody] RequestDtoAdministration_Update requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.UpdateAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpDelete("AdministrationDeleteAsync")]
        //public async Task<IActionResult> AdministrationDeleteAsync([FromBody] RequestDtoAdministration_Delete requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.DeleteAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("AdministrationGetByIdAsync")]
        //public async Task<IActionResult> AdministrationGetByIdAsync([FromBody] RequestDtoAdministration_GetById requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.GetByIdAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("AdministrationGetByResourceAsync")]
        //public async Task<IActionResult> AdministrationGetByResourceAsync([FromBody] RequestDtoAdministration_GetByResource requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.GetByResourceAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("AdministrationGetByRoleAsync")]
        //public async Task<IActionResult> AdministrationGetByRoleAsync([FromBody] RequestDtoAdministration_GetByRole requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.GetByRoleAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpGet("AdministrationListAsync")]
        //public async Task<IActionResult> AdministrationListAsync()
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    var response = await _entityApplication.ListAsync();
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("AdministrationListWithPaginationAsync")]
        //public async Task<IActionResult> AdministrationListWithPaginationAsync([FromBody] RequestDtoAdministration_ListWithPagination requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.ListWithPaginationAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        #endregion

    }
}
