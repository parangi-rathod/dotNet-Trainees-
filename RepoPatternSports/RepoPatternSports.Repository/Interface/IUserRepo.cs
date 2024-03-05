using RepoPatternSports.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Interface
{
    public interface IUserRepo
    {
        Task<User> GetUserById(int id);
        Task<bool> CheckCaptain(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByEmailAndPass(string email, byte[] password);
    }
}
