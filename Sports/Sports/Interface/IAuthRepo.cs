using Sports.Model;
using System.Threading.Tasks;

namespace Sports.Interface
{
    public interface IAuthRepo
    {
        Task<bool> Register(RegisterModel registerModel);
        Task<string> Login(LoginModel loginModel);
        Task<bool> CheckCaptain(User user);
        Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
