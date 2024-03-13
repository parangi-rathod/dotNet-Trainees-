using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Interface
{

    public interface IAuthRepo
    {
        Task<bool> Register(User user);
        Task<User> Login(string email, string password);
        Task<string> UserExists(string email);   
    }
}
