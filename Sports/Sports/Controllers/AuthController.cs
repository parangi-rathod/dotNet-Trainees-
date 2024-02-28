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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authService.Login(loginModel);
            return Ok(result); // You might consider returning a JSON object or a more structured response
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.Register(registerModel);
            _emailService.SendRegisterMail(registerModel.Email, "Welcome");
            return Ok(result); // Similarly, you might consider returning a JSON object or a more structured response
        }

        #endregion

    }
}
