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
    public class GroupMenuController : Controller
    {

        private readonly IGroupMenuApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        private string Method = string.Empty;

        public GroupMenuController(IGroupMenuApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("GroupMenuRegister")]
        public IActionResult GroupMenuRegister([FromBody] RequestDtoGroupMenu_Insert requestDto)
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

        [HttpPut("GroupMenuActualice")]
        public IActionResult GroupMenuActualice([FromBody] RequestDtoGroupMenu_Update requestDto)
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

        [HttpDelete("GroupMenuDelete")]
        public IActionResult GroupMenuDelete([FromBody] RequestDtoGroupMenu_Delete requestDto)
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

        [HttpPatch("GroupMenuGetById")]
        public IActionResult GroupMenuGetById([FromBody] RequestDtoGroupMenu_GetById requestDto)
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

        [HttpGet("GroupMenuList")]
        public IActionResult GroupMenuList()
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

        [HttpPatch("GroupMenuListWithPagination")]
        public IActionResult GroupMenuListWithPagination([FromBody] RequestDtoGroupMenu_ListWithPagination requestDto)
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

        //[HttpPost("GroupMenuRegisterAsync")]
        //public async Task<IActionResult> GroupMenuRegisterAsync([FromBody] RequestDtoGroupMenu_Insert requestDto)
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

        //[HttpPut("GroupMenuActualiceAsync")]
        //public async Task<IActionResult> GroupMenuActualiceAsync([FromBody] RequestDtoGroupMenu_Update requestDto)
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

        //[HttpDelete("GroupMenuDeleteAsync")]
        //public async Task<IActionResult> GroupMenuDeleteAsync([FromBody] RequestDtoGroupMenu_Delete requestDto)
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

        //[HttpPatch("GroupMenuGetByIdAsync")]
        //public async Task<IActionResult> GroupMenuGetByIdAsync([FromBody] RequestDtoGroupMenu_GetById requestDto)
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

        //[HttpGet("GroupMenuListAsync")]
        //public async Task<IActionResult> GroupMenuListAsync()
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

        //[HttpPatch("GroupMenuListWithPaginationAsync")]
        //public async Task<IActionResult> GroupMenuListWithPaginationAsync([FromBody] RequestDtoGroupMenu_ListWithPagination requestDto)
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
