using Microsoft.EntityFrameworkCore;
using Sports.Model;

namespace Sports.Repository
{
    public class UserRepo
    {
        #region prop
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public UserRepo(AppDbContext context)
        {
            _context= context;
        }
        #endregion

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
