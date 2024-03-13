using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository.Interface
{
    public interface ICoachRepo
    {
        Task<bool> AssignCaptain(int id);
        Task UpdateUserIsMem(int id);
        Task<List<User>> ViewTeam();
    }
}
