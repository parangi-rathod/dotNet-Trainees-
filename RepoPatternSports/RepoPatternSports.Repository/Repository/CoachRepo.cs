using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Repository
{
    public class CoachRepo : ICoachRepo
    {

        #region prop
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public CoachRepo(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        #endregion

        #region methods
        public async Task<bool> AssignCaptain(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
            res.role = Role.Captain;
            res.isMember = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task UpdateUserIsMem(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);

            if (user != null)
            {
                user.isMember = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> CaptainExists(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id && u.role == Role.Captain);
            return res != null;
        }


        public async Task<List<User>> ViewTeam()
        {
            var usersWithMembership = await _context.UserModel.Where(u => u.isMember == true).ToListAsync();
            return usersWithMembership;
        }
        #endregion
    }
}
