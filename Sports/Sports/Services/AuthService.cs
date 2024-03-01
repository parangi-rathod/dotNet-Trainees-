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
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
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
                return "Registered Successfully";
            }
            return "Can't registered";
        }

    }

    #endregion
}

