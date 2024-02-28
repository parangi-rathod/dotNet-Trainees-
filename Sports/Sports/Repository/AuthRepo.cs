using Microsoft.EntityFrameworkCore;
using Sports.Interface;
using Sports.Model;

namespace Sports.Repository
{
    public class AuthRepo : IAuthRepo
    {

        #region prop
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        #endregion

        #region ctor
        public AuthRepo(AppDbContext context, IConfiguration configuration)
        {
                _context = context;
            _configuration = configuration;
        }
        #endregion

        #region Login Register method
        public async Task<bool> Register(RegisterModel registerModel)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(registerModel.Password, out passwordHash, out passwordSalt);

                // Create a new User object and populate its properties
                var user = new User
                {
                    Firstname = registerModel.Firstname,
                    Lastname = registerModel.Lastname,
                    Password = registerModel.Password, // Assuming Password is plain-text for now
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    ContactNumber = registerModel.ContactNumber,
                    Email = registerModel.Email,
                    DateOfBirth = registerModel.DateOfBirth,
                    role = registerModel.role,
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            var DefaultPassword = "team1234";
            var loggedUser = _context.Users.FirstOrDefault(u => u.Email == loginModel.Email);
            bool flag;
            if(loggedUser == null) 
            {
                flag= false;  //user not found
            }
            if (loginModel.Password == DefaultPassword || VerifyPasswordHash(loginModel.Password, loggedUser.PasswordHash, loggedUser.PasswordSalt))
            {
                // Either the default password or the user's password matches
                return true;
            }
            else
            {
                // Password not matched
                return false;
            }
            return flag;
        }

        #endregion

        #region miscellaneous methods
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion

    }
}
