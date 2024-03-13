using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Controllers
{
    [Authorize(Roles ="Player")]
    public class PlayerController : BaseController
    {
        #region prop
        private readonly IPlayerService _playerService;
        #endregion

        #region ctor
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        #endregion

        #region apis
        [HttpGet]
        [Route("Dashboard/ViewCoachAndCaptain")]
        public async Task<IActionResult> GetCoachAndCaptain()
        {
            var coachTask = _playerService.GetCoach();
            var captainTask = _playerService.GetCaptain();

            var coach = await coachTask;
            var captain = await captainTask;

            var coachAndCaptain = new
            {
                Coach = coach,
                Captain = captain
            };

            return Ok(coachAndCaptain);
        }


        #endregion
    }
}
