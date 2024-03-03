using Sports.Model;

namespace Sports.Interface
{
    public interface IPlayerRepo
    {
        Task<User> GetCoach();
        Task<User> GetCaptain();
    }
}
