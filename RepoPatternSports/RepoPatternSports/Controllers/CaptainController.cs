﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Controllers
{
    [Authorize(Roles ="Captain")]
    public class CaptainController : BaseController
    {
        #region props
        private readonly ICaptainService _captainService;
        #endregion

        #region ctor
        public CaptainController(ICaptainService captainService)
        {
            _captainService = captainService;
        }
        #endregion

        #region apis
        [HttpPut]
        [Route("FinalTeam")]
        public async Task<IActionResult> FormFinalTeam(int id)
        {
            var res = await _captainService.FormFinalTeam(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("Dashboard")]
        public async Task<IActionResult> GetTeam()
        {
            var res = await _captainService.ViewTeam();
            return Ok(res);
        }
        #endregion
    }
}
