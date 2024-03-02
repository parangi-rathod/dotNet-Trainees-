using Sports.Model;

namespace Sports.Interface
{
    public interface ICoachRepo
    {
        Task<bool> AssignCaptain(int id);
        Task<bool> CaptainExists(int id);
        Task<User> GetUserById(int id);
    }
}
