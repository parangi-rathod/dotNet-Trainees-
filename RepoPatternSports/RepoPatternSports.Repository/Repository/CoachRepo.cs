using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Repository
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

        #region methods
        public async Task<bool> AssignCaptain(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
            res.role = Role.Captain;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CaptainExists(int id)
        {
            var res = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId.Equals(id) && u.role.Equals(Role.Captain));
            if (res != null)
            {
                return true; //yes, captain already exists
            }
            return false;
        }
        #endregion
    }
}
