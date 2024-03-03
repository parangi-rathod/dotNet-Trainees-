using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Interface;
using Sports.Model;
using Sports.Repository;

namespace Sports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AuthController : ControllerBase
    {
        #region props

        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        #endregion

        #region ctor
        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        #endregion


        #region APIs
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string token = await _authService.Login(loginModel);

            if (!string.IsNullOrEmpty(token))
            {
                var response = new { Token = token };
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid email or password");
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.Register(registerModel);
            return Ok(result); 
        }

        [HttpPost("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _authService.ResetPassword(resetPasswordDTO);
            return Ok(result);
        }

        #endregion

    }
}
