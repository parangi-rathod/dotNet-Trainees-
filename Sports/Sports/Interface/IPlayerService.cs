using Sports.Model;

namespace Sports.Interface
{
    public interface IPlayerService
    {
        Task<User> GetCoach();
        Task<User> GetCaptain();
    }
}
