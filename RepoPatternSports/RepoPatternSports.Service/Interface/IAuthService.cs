using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface IAuthService
    {
        Task<ResponseDTO> Register(RegisterDTO registerDTO);
        Task<ResponseDTO> Login(LoginDTO loginDTO);
        Task<ResponseDTO> ResetPassword(ResetPasswordDTO resetPasswordDTO);

    }
}
