using Microsoft.EntityFrameworkCore;
using Sports.Interface;
using Sports.Model;

namespace Sports.Repository
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
    }
}
