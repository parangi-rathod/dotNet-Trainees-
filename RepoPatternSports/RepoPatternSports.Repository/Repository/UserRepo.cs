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

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId.Equals(id));
            return user;
        }
        public async Task<bool> CheckCaptain(User user)
        {
            bool isCaptainRegistered = await _context.UserModel.AnyAsync(u => u.role.Equals(Role.Captain));
            return isCaptainRegistered;
        }

    }
}
