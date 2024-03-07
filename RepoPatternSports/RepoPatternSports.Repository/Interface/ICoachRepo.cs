using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Interface
{
    public interface ICoachRepo
    {
        Task<bool> AssignCaptain(int id);
        Task UpdateUserIsMem(int id);
        Task<List<User>> ViewTeam();
    }
}
