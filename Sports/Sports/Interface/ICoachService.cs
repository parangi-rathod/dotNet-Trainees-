using Sports.Model;

namespace Sports.Interface
{
    public interface ICoachService
    {
        Task<string> AssignCaptain(int id);
        Task<List<User>> AddPlayerToTeam(int id);
    }
    
}
