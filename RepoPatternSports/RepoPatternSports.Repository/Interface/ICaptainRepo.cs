using RepoPatternSports.Repository.Models;

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
