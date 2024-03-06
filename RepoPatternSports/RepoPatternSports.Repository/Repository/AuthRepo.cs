using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Repository
{
    public class AuthRepo : IAuthRepo
    {
        #region prop
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public AuthRepo(AppDbContext context)
        {
            _context= context;
        }
        #endregion

        #region methods
        public async Task<bool> Register(User user)
        {
            if(user!=null)
            {
                _context.UserModel.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<User> Login(string email, string password)
        {
            string checkUserExists = await UserExists(email);
            if(checkUserExists == null)
            {
                return null;
            }
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
            return user;

        }
        public async Task<string> UserExists(string email)
        {
            var user = await _context.UserModel.AnyAsync(u => u.Email.Equals(email));

            if (user != null)
            {
                return email;
            }
            else
            {
                return "";
            }
        }

        
        #endregion
    }
}
