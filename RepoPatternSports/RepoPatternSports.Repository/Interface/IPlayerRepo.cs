using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Interface
{
    public interface IPlayerRepo
    {
        Task<User> GetCoach();
        Task<User> GetCaptain();
    }
}
