using Sports.Model;

namespace Sports.Interface
{
    public interface IAuthService
    {
        Task<string> Register(RegisterModel registerModel);
        Task<string> Login(LoginModel loginModel);
    }
}
