﻿using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Controllers
{
    public class AuthController : BaseController
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

        [HttpPost("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _authService.ResetPassword(resetPasswordDTO);
            return Ok(result);
        }
        #endregion
    }
}
