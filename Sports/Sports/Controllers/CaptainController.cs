using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Interface;
using Sports.Model;
using Sports.Services;

namespace Sports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Captain")]
    public class CaptainController : ControllerBase
    {
        private readonly ICaptainService _captainService;

        public CaptainController(ICaptainService captainService)
        {
            _captainService= captainService;
        }

        [HttpGet]
        [Route("FinalTeam")]
        public async Task<ActionResult> FormFinalTeam(int id)
        {
            var res = await _captainService.FormFinalTeam(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("ViewPlayers")]
        public IActionResult GetTeam()
        {
            return Ok(Team.FinalTeam);
        }

    }
}
