using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Repository
{
    public class PlayerRepo : IPlayerRepo
    {
        #region prop
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public PlayerRepo(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        public async Task<User> GetCaptain()
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.role == Role.Captain);
            return res;
        }

        public async Task<User> GetCoach()
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.role == Role.Coach);
            return res;
        }
        #endregion
    }
}
