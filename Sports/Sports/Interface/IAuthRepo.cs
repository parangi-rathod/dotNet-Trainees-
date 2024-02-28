using Sports.Model;

namespace Sports.Interface
{
    public interface IAuthRepo
    {
        Task<bool> Register(RegisterModel registerModel);
        Task<bool> Login(LoginModel luser);
    }
}
