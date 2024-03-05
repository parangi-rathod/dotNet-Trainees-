using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Controllers
{
    [Authorize(Roles ="Captain")]
    [Route("api/[controller]")]
    [ApiController]
    public class CaptainController : ControllerBase
    {
        private readonly ICaptainService _captainService;

        public CaptainController(ICaptainService captainService)
        {
            _captainService = captainService;
        }

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
    }
}
