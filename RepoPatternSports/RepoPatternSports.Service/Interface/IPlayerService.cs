using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface IPlayerService
    {
        Task<User> GetCoach();
        Task<User> GetCaptain();
    }
}
