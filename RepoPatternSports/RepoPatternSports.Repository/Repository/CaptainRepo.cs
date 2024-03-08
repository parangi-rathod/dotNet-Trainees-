using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Repository
{
    public class CaptainRepo : ICaptainRepo
    {
        #region props
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public CaptainRepo(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        public async Task<User> CheckIsMem(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId.Equals(id));

            if (user != null && !user.isMember)
            {
                // Update isMem to true if the user exists and is not already a member
                user.isMember = true;
                await _context.SaveChangesAsync(); 
            }

            return user;
        }


        public async Task<int> CountIsMemPlayers()
        {
            int count = await _context.UserModel.Where(u => u.isMember).CountAsync();
            return count;
        }

        public async Task<List<User>> GetIsMemPlayers()
        {
            List<User> teamMembers = await _context.UserModel.Where(u => u.isMember).ToListAsync();
            return teamMembers;
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
        #endregion
    }
}
