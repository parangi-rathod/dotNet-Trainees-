using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.Model;

namespace Sports.Controllers
{
    [Authorize(Roles="Coach")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CoachController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> AddPlayer()
        {
            var res = await _context.Users.ToListAsync();
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> AssignCaptain()
        {
            var res = await _context.Users.ToListAsync();
            return Ok(res);
        }
    }
}
