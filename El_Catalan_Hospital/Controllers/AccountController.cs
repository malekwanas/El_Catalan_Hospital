using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.Errors;
using El_Catalan_Hospital.BLL.Responses;
using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace El_Catalan_Hospital.API.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAuthService authService, ILogger<AccountController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        //---------------------------------------------- patient register ---------------------------------------------//
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto model )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new Response
                    {
                        Message = ErrorMsg.InvalidProperties,
                        isSucceeded = false,
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }


                var result = await _authService.RegisterPatientAsync(model);

                if (result.isSucceeded)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMsg.AnErrorOccured);
                return StatusCode(500, new Response
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    isSucceeded = false,
                    Errors = new[] { ex.Message }
                });
            }
        }
        //------------------------------------------------------------------------ login -----------------------------------------//
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _authService.LoginUserAsync(model);
                    if (result.isSucceeded)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest(ErrorMsg.InvalidProperties);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

