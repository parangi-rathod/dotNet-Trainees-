using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Cmp;
using Sports.Interface;
using Sports.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sports.Repository
{
    public class AuthRepo : IAuthRepo
    {

        #region prop
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public AuthRepo(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        #endregion

        #region Login Register method

        public async Task<string> Login(LoginModel loggingUser)
        {
            var userEmail = await UserExists(loggingUser);
            if (userEmail != null)
            {
                var user = await _context.UserModel.FirstOrDefaultAsync(u => u.Email == userEmail);

                byte[] inputPasswordHash = CreatePasswordHash(loggingUser.Password);
                if (Convert.ToBase64String(inputPasswordHash) == Convert.ToBase64String(user.Password))
                {
                    string userRoleString = user.role.ToString();
                    return await GenerateJwtToken(userRoleString);
                }
            }
            return "";
        }

        public async Task<string> UserExists(LoginModel loginModel)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.Email == loginModel.Email);

            if (user != null)
            {
                return user.Email;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            byte[] passwordHash;
            passwordHash= CreatePasswordHash(registerModel.Password);

            var user = new User
            {
                    Firstname = registerModel.Firstname,
                    Lastname = registerModel.Lastname,
                    Password = passwordHash,
                    ContactNumber = registerModel.ContactNumber,
                    Email = registerModel.Email,
                    DateOfBirth = registerModel.DateOfBirth,
                    role = registerModel.role,
            };
            try
            {
                _context.UserModel.Add(user);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during registration: {ex.Message}");
                return false; 
            }


        }

        #endregion

        #region miscellaneous methods


        public async Task<string> GenerateJwtToken(string userRole)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(_config["JWT:Issuer"], _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }



        private byte[] CreatePasswordHash(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion

    }
}
