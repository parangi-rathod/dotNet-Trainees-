using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RepoPatternSports.Service.Service
{
    public class AuthService : IAuthService
    {
        #region properties
        private readonly IAuthRepo _authRepo;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IUserRepo _userRepo;
        private readonly IPasswordHash _passwordHash;
        #endregion

        #region ctor
        public AuthService(IAuthRepo authRepo, IConfiguration configuration, IEmailService emailService, IUserRepo userRepo, IPasswordHash passwordHash)
        {
            _authRepo = authRepo;
            _config = configuration;
            _emailService = emailService;
            _userRepo = userRepo;
            _passwordHash = passwordHash;
        }

        #endregion

        #region methods
        public async Task<ResponseDTO> Register(RegisterDTO registerDTO)
        {
            string passwordHash;
            passwordHash = _passwordHash.CreatePasswordHash(registerDTO.Password);

            //var checkCoach = await _userRepo.CheckCoach();

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
                if (await _userRepo.uniqueEmail(registerDTO.Email))
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = $"User with email address {registerDTO.Email} already exists in the system!"
                    };
                }
                if (((user.role == Role.Coach && (await _userRepo.CheckCoach()) == false) && user.role != Role.Captain) || user.role == Role.Player)
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
            string PassHash = _passwordHash.CreatePasswordHash(loginDTO.Password);
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
            try
            {
                string hashedform = _passwordHash.CreatePasswordHash(resetPasswordDTO.OldPassword);
                var user = await _userRepo.GetUserByEmailAndPass(resetPasswordDTO.Email, hashedform);
                if (user == null)
                {
                    return new ResponseDTO()
                    {
                        Status = 400,
                        Message = "User not found : try to add correct details"
                    };
                }
                string HashedFormOfNewPassword = _passwordHash.CreatePasswordHash(resetPasswordDTO.NewPassword);
                user.Password = HashedFormOfNewPassword;
                var updateUser = await _userRepo.UpdateUser(user);
                if (updateUser != null)
                {
                    var emailObj = new EmailDTO
                    {
                        Email = user.Email,
                        Subject = "Password reset",
                        Body = "Your Password changed successfully!"
                    };
                    _emailService.SendEmail(emailObj);
                    return new ResponseDTO
                    {
                        Status = 200,
                        Message = "Password changed successfully!!"
                    };
                    
                }
                else
                {
                    return new ResponseDTO()
                    {
                        Status = 400,
                        Message = "Failed"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Status = 400,
                    Message = "Failed",
                    Error = ex.Message
                };
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
