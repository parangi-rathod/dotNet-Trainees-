using Sports.Interface;
using Sports.Model;

namespace Sports.Services
{
    public class AuthService : IAuthService
    {
        #region properties
        private readonly IAuthRepo _authRepo;
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
            bool res = await _authRepo.Login(loginModel);

            if(res == false) 
            {
                return "Invalid Username or Password";
            }
            return "Logged in Successfully!";
        }

        public async Task<string> Register(RegisterModel registerModel)
        {
            bool res = await _authRepo.Register(registerModel);
            if(res == false)
            {
                return "Interval Server Error";
            }
            return "Registered Successfully";
        }

        #endregion
    }
}
