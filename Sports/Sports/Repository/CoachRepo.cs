using Microsoft.EntityFrameworkCore;
using Sports.Interface;
using Sports.Model;

namespace Sports.Repository
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


        public async Task<bool> AssignCaptain(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
            res.role = Role.Captain;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CaptainExists(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
            if(res!=null)
            {
                return true; //yes, captain already exists
            }
            return false;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return user;
        }
    }
}
