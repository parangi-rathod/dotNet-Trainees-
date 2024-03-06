using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Repository
{
    public class UserRepo : IUserRepo
    {
        #region prop
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }


        #endregion

        #region methods
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId.Equals(id));
            return user;
        }

        public async Task<User> GetUserByEmailAndPass(string email, string password)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.UserModel.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckCaptain(User user)
        {
            bool isCaptainRegistered = await _context.UserModel.AnyAsync(u => u.role.Equals(Role.Captain));
            return isCaptainRegistered;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<int> GetTeamMembersCount()
        {
            int count = await _context.UserModel.CountAsync(u => u.isMember);
            return count;
        }
        #endregion

    }
}
