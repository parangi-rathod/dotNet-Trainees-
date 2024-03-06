using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Interface
{

    public interface IAuthRepo
    {
        Task<bool> Register(User user);
        Task<User> Login(string email, string password);
        Task<string> UserExists(string email);   
    }
}
