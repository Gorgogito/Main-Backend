using Main.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Main.Service.WebApi.Controllers
{

    [Authorize]
    [Route("api/function/[controller]")]
    [ApiController]
    public class EncryptingController : Controller
    {

        private readonly IEncryptingApplication _entityApplication;
        private readonly Solutions.Utility.AppLogger.ILogger _logger;

        public EncryptingController(IEncryptingApplication entityApplication, Solutions.Utility.AppLogger.ILogger logger)
        {
            _entityApplication = entityApplication;
            _logger = logger;
        }

        #region "Métodos Sincronos"

        [AllowAnonymous]
        [HttpPatch("EncryptString")]
        public IActionResult EncryptString([FromBody] string requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.EncryptString(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response); 
            }

            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPatch("DecryptString")]
        public IActionResult DecryptString([FromBody] string requestDto)
        {
            _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
            if (requestDto == null)
                return BadRequest();
            var response = _entityApplication.DecryptString(requestDto);
            if (response.IsSuccess)
            {
                _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
                return Ok(response);
            }

            return BadRequest(response);
        }

        #endregion

        #region "Métodos Asincronos"

        //[AllowAnonymous]
        //[HttpPatch("EncryptStringAsync")]
        //public async Task<IActionResult> EncryptStringAsync([FromBody] string requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    if (requestDto == null)
        //        return BadRequest();
        //    var response = await _entityApplication.EncryptStringAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        //[AllowAnonymous]
        //[HttpPatch("DecryptStringAsync")]
        //public async Task<IActionResult> DecryptStringAsync([FromBody] string requestDto)
        //{
        //    _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Accediendo al servicio");
        //    var response = await _entityApplication.DecryptStringAsync(requestDto);
        //    if (response.IsSuccess)
        //    {
        //        _logger.InfoFormat("[{0}-{1}] - {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Servicio Exitoso!!!");
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);
        //}

        #endregion

    }
}
