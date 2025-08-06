using Main.Application.DTO.Request;
using Main.Application.Interface;
using Main.Cross.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Main.Service.WebApi.Controllers
{

    [Authorize]
    [Route("api/identy/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        public UserController(IUserApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [HttpPost("UserRegister")]
        public IActionResult UserRegister([FromBody] RequestDtoUser_Insert requestDto)
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

        [HttpPut("UserActualice")]
        public IActionResult UserActualice([FromBody] RequestDtoUser_Update requestDto)
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

        [HttpDelete("UserDelete")]
        public IActionResult UserDelete([FromBody] RequestDtoUser_Delete requestDto)
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

        [HttpPatch("UserGetById")]
        public IActionResult UserGetById([FromBody] RequestDtoUser_GetById requestDto)
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

        [HttpGet("UserList")]
        public IActionResult UserList()
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

        [HttpPatch("UserListWithPagination")]
        public IActionResult UserListWithPagination([FromBody] RequestDtoUser_ListWithPagination requestDto)
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

        //[HttpPost("UserRegisterAsync")]
        //public async Task<IActionResult> UserRegisterAsync([FromBody] RequestDtoUser_Insert requestDto)
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

        //[HttpPut("UserActualiceAsync")]
        //public async Task<IActionResult> UserActualiceAsync([FromBody] RequestDtoUser_Update requestDto)
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

        //[HttpDelete("UserDeleteAsync")]
        //public async Task<IActionResult> UserDeleteAsync([FromBody] RequestDtoUser_Delete requestDto)
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

        //[HttpPatch("UserGetByIdAsync")]
        //public async Task<IActionResult> UserGetByIdAsync([FromBody] RequestDtoUser_GetById requestDto)
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

        //[HttpGet("UserListAsync")]
        //public async Task<IActionResult> UserListAsync()
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

        //[HttpPatch("UserListWithPaginationAsync")]
        //public async Task<IActionResult> UserListWithPaginationAsync([FromBody] RequestDtoUser_ListWithPagination requestDto)
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
