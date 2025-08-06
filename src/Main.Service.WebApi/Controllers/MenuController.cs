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
    public class MenuController : Controller
    {

        private readonly IMenuApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string Method = string.Empty;

        public MenuController(IMenuApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("MenuRegister")]
        public IActionResult MenuRegister([FromBody] RequestDtoMenu_Insert requestDto)
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

        [HttpPut("MenuActualice")]
        public IActionResult MenuActualice([FromBody] RequestDtoMenu_Update requestDto)
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

        [HttpDelete("MenuDelete")]
        public IActionResult MenuDelete([FromBody] RequestDtoMenu_Delete requestDto)
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

        [HttpPatch("MenuGetById")]
        public IActionResult MenuGetById([FromBody] RequestDtoMenu_GetById requestDto)
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

        [HttpPatch("MenuGetByGroupMenu")]
        public IActionResult MenuGetByGroupMenu([FromBody] RequestDtoMenu_GetByGroupMenu requestDto)
        {
            Method = MethodBase.GetCurrentMethod()!.Name;
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.GetByGroupMenu(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("MenuList")]
        public IActionResult MenuList()
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

        [HttpPatch("MenuListWithPagination")]
        public IActionResult MenuListWithPagination([FromBody] RequestDtoMenu_ListWithPagination requestDto)
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

        //[HttpPost("MenuRegisterAsync")]
        //public async Task<IActionResult> MenuRegisterAsync([FromBody] RequestDtoMenu_Insert requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.InsertAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPut("MenuActualiceAsync")]
        //public async Task<IActionResult> MenuActualiceAsync([FromBody] RequestDtoMenu_Update requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.UpdateAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpDelete("MenuDeleteAsync")]
        //public async Task<IActionResult> MenuDeleteAsync([FromBody] RequestDtoMenu_Delete requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.DeleteAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("MenuGetByIdAsync")]
        //public async Task<IActionResult> MenuGetByIdAsync([FromBody] RequestDtoMenu_GetById requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.GetByIdAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("MenuGetByGroupMenuAsync")]
        //public async Task<IActionResult> MenuGetByGroupMenuAsync([FromBody] RequestDtoMenu_GetByGroupMenu requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.GetByGroupMenuAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpGet("MenuListAsync")]
        //public async Task<IActionResult> MenuListAsync()
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    var response = await _entityApplication.ListAsync();
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[HttpPatch("MenuListWithPaginationAsync")]
        //public async Task<IActionResult> MenuListWithPaginationAsync([FromBody] RequestDtoMenu_ListWithPagination requestDto)
        //{
        //    Method = MethodBase.GetCurrentMethod()!.Name;
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.ListWithPaginationAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, Method, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        #endregion

    }
}
