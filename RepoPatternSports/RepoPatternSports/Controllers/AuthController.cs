using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Service.Interface;
using RepoPatternSports.Repository.DTOs;

namespace RepoPatternSports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region props

        private readonly IAuthService _authService;

        #endregion

        #region ctor
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region APIs

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
           return Ok(await _authService.Login(loginDTO));               
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            return Ok(await _authService.Register(registerDTO));
        }
        #endregion
    }
}
