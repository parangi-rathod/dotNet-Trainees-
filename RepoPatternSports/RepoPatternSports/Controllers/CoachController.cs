using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Controllers
{
    [Authorize(Roles ="Coach")]
    public class CoachController : BaseController
    {
        #region props
        private readonly ICoachService _coachService;
        #endregion

        #region ctor
        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }
        #endregion

        #region apis
        [HttpGet]
        [Route("AddPlayers")]
        public async Task<ActionResult> AddPlayer(int id)
        {
            var res = await _coachService.AddPlayerToTeam(id);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut]
        [Route("AssignCaptain")]
        public async Task<IActionResult> AssignCaptain(int id)
        {
            var res = await _coachService.AssignCaptain(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("ViewPlayers")]
        public async Task<IActionResult> GetTeam()
        {
            var res = await _coachService.ViewTeam();
            return Ok(res);
        }
        #endregion
    }
}
