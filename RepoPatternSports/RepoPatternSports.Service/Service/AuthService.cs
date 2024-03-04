using Microsoft.IdentityModel.Tokens;
using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using MimeKit;

namespace RepoPatternSports.Service.Service
{
    public class AuthService : IAuthService
    {
        #region properties
        private readonly IAuthRepo _authRepo;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IUserRepo _userRepo;
        #endregion

        #region ctor
        public AuthService(IAuthRepo authRepo, IConfiguration configuration, IEmailService emailService, IUserRepo userRepo)
        {
            _authRepo = authRepo;
            _config = configuration;
            _emailService = emailService;
            _userRepo = userRepo;
        }

        #endregion

        #region methods
        public async Task<ResponseDTO> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash;
            passwordHash = CreatePasswordHash(registerDTO.Password);
            var user = new User
            {
                Firstname = registerDTO.Firstname,
                Lastname = registerDTO.Lastname,
                Password = passwordHash,
                ContactNumber = registerDTO.ContactNumber,
                Email = registerDTO.Email,
                DateOfBirth = registerDTO.DateOfBirth,
                role = registerDTO.role,
            };
            try
            {
                if (user.role != Role.Coach && user.role != Role.Captain)
                {
                    var res = _authRepo.Register(user);
                    if (res != null)
                    {
                        var emailObj = new EmailDTO
                        {
                            Email = user.Email,
                            Subject = "Registration",
                            Body = "Welcome, you have registered successfully"
                        };
                        _emailService.SendEmail(emailObj);
                        return new ResponseDTO
                        {
                            Status = 200,
                            Message = "User registered successfully!"
                        };
                    }
                    else
                    {
                        return new ResponseDTO
                        {
                            Status = 400,
                            Message = "User not registered!"
                        };
                    }
                }
                else
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = "Invalid role for registration!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Status = 400,
                    Message = "Failed",
                    Error = $"Error occurred during registration: {ex.Message}"
                };
            }
        }

        public async Task<ResponseDTO> Login(LoginDTO loginDTO)
        {
            byte[] PassHash = CreatePasswordHash(loginDTO.Password);
            var user = await _authRepo.Login(loginDTO.Email, PassHash); // Assuming this is your login method returning a user.
            if (user != null)
            {
                string userRoleString = user.role.ToString();
                string token = await GenerateJwtToken(userRoleString);

                // Now, you need to return the token as part of your ResponseDTO
                return new ResponseDTO
                {
                    Status = 200,
                    Data = token,
                    Message = "Login successful",
                };
            }
            else
            {
                return new ResponseDTO
                {
                    Status = 400,
                    Message = "Invalid email or password"
                };
            }
        }

        public async Task<ResponseDTO> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userRepo.GetUserByEmail(resetPasswordDTO.Email);
            if (user != null)
            {
                byte[] hashedPass = CreatePasswordHash(resetPasswordDTO.NewPassword);
                user.Password = hashedPass;
                await _userRepo.UpdateUser(user);
                return new ResponseDTO
                {
                    Status = 200,
                    Message = "Password modified!"
                };
            }
            return new ResponseDTO
            {
                Status= 400,
                Message = "Password Can't modified"
            };
        }



        #endregion

        #region miscellaneous methods

        private byte[] CreatePasswordHash(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<string> GenerateJwtToken(string userRole)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(_config["JWT:Issuer"], _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        #endregion


    }
}
