using Sports.Model;

namespace Sports.Interface
{
    public interface IUserRepo
    {
        Task<User> GetUserById(int id);
        Task<bool> CheckCaptain(User user);
    }
}
