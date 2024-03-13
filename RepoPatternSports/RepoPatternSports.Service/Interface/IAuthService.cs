using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface IAuthService
    {
        Task<ResponseDTO> Register(RegisterDTO registerDTO);
        Task<ResponseDTO> Login(LoginDTO loginDTO);
        Task<ResponseDTO> ResetPassword(ResetPasswordDTO resetPasswordDTO);

    }
}
