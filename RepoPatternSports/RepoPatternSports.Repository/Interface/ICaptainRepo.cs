using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Interface
{
    public interface ICaptainRepo
    {
        Task UpdateUserIsMem(int id);
        Task<User> CheckIsMem(int id);
        Task<int> CountIsMemPlayers();
        Task<List<User>> GetIsMemPlayers();
    }
}
