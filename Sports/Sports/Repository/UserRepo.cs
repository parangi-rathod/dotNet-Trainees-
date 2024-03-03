using Microsoft.EntityFrameworkCore;
using Sports.Interface;
using Sports.Model;

namespace Sports.Repository
{
    public class UserRepo:IUserRepo
    {
        #region prop
        private readonly AppDbContext _context;
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
        public async Task<bool> CheckCaptain(User user)
        {
            bool isCaptainRegistered = await _context.UserModel.AnyAsync(u => u.role == Role.Captain);
            return isCaptainRegistered;
        }

    }
}
