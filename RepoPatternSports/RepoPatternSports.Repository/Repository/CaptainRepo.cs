using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Repository
{
    public class CaptainRepo : ICaptainRepo
    {
        private readonly AppDbContext _context;
        public CaptainRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CheckIsMem(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId.Equals(id));

            if (user != null && !user.isMember)
            {
                // Update isMem to true if the user exists and is not already a member
                user.isMember = true;
                await _context.SaveChangesAsync(); // Save the changes to the database
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
    }
}
