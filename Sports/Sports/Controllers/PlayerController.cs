using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Services;

namespace Sports.Controllers
{
    [Authorize("Player")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        #region prop
        PlayerService _playerService;
        #endregion

        #region ctor
        public PlayerController(PlayerService playerService)
        {
            _playerService= playerService;
        }
        #endregion

        #region apis
        [HttpGet]
        [Route("ViewCoach")]
        public async Task<ActionResult> GetCoach()
        {
            var Coach = await _playerService.GetCoach();
            return Ok(Coach.Firstname);
        }
        [HttpGet]
        [Route("ViewCaptain")]
        public async Task<ActionResult> GetCaptain()
        {
            var Captain = await _playerService.GetCaptain();
            return Ok(Captain.Firstname);
        }
        #endregion
    }
}
