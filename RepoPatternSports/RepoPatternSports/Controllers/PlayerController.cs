using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Service.Interface;
using RepoPatternSports.Service.Service;

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
        [Route("ViewCoach")]
        public async Task<IActionResult> GetCoach()
        {
            var Coach = await _playerService.GetCoach();
            return Ok(Coach);
        }
        [HttpGet]
        [Route("ViewCaptain")]
        public async Task<IActionResult> GetCaptain()
        {
            var Captain = await _playerService.GetCaptain();
            return Ok(Captain);
        }
        #endregion
    }
}
