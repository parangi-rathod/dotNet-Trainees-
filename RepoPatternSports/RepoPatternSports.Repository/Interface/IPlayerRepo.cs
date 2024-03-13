using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Interface
{
    public interface IPlayerRepo
    {
        Task<User> GetCoach();
        Task<User> GetCaptain();
    }
}
