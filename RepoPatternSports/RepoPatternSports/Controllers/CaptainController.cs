using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Repository.Models;
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
        [HttpGet]
        [Route("FinalTeam")]
        public async Task<ActionResult> FormFinalTeam(int id)
        {
            var res = await _captainService.FormFinalTeam(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("ViewFinalTeamPlayers")]
        public async Task<ActionResult> GetTeam()
        {
            var res = await _captainService.ViewTeam();
            return Ok(res);
        }
        #endregion
    }
}
