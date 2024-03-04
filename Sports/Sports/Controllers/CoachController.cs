using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sports.Interface; // Assuming ICoachService is in this namespace
using Sports.Model;
using Microsoft.AspNetCore.Authorization;

namespace Sports.Controllers
{
    [Authorize(Roles ="Coach")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet]
        [Route("AddPlayers")]
        public async Task<ActionResult> AddPlayer(int id)
        {
            var res = await _coachService.AddPlayerToTeam(id);
            if(res != null)
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
        public IActionResult GetTeam()
        {
            return Ok(Team.Players); 
        }
    }
}
