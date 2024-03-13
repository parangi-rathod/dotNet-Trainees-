using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Interface
{
    public interface IUserRepo
    {
        Task<User> GetUserById(int id);
        Task<bool> CheckCaptain();
        Task<User> UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByEmailAndPass(string email, string password);
        Task<int> GetTeamMembersCount();
        Task<bool> uniqueEmail(string email);
        Task<bool> CheckCoach();
        Task<bool> CheckRowCountLessThan16();
        Task<int> CountEntries();
    }
}
