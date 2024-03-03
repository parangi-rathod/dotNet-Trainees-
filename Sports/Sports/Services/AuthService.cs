using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sports.Interface;
using Sports.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sports.Services
{
    public class AuthService : IAuthService
    {
        #region properties
        private readonly IAuthRepo _authRepo;
        private readonly IEmailService _emailService;
        #endregion

        #region ctor
        public AuthService(IAuthRepo authRepo, IEmailService emailService)
        {
            _authRepo = authRepo;
            _emailService = emailService;
        }
        #endregion

        #region methods


        public async Task<string> Login(LoginModel loginModel)
        {
            string res = await _authRepo.Login(loginModel);
            if (res!=null)
            {
                return res;
            }
            return "Doesn't logged in";
        }

        public async Task<string> Register(RegisterModel registerModel)
        {
            bool res = await _authRepo.Register(registerModel);
            if (res)
            {
                _emailService.SendRegisterMail(registerModel.Email, "Welcome");
                return "Registered Successfully";
            }
            return "Can't registered";
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            bool res = await _authRepo.ResetPassword(resetPasswordDTO);
            if (res)
            {
                _emailService.SendResetPassEmail(resetPasswordDTO.Email, "Change of Password");
                return true;
            }
            return false;
        }
    }

    #endregion
}

