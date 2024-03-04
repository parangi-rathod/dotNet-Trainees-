using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Service
{
    public class UserService
    {
        #region prop
        private readonly IUserRepo _userRepo;
        #endregion

        #region ctor
        public UserService(IUserRepo userRepo)
        {
            _userRepo= userRepo;
        }
        #endregion
        public async Task<ResponseDTO> GetUserById(int id)
        {
            var user = await _userRepo.GetUserById(id);
            if(user == null)
            {
                return new ResponseDTO
                {
                    Status = 400,
                    Message = $"User with given {id} doesn't exists"
                };
            }
            return new ResponseDTO
            {
                Status = 200,
                Message = $"User exists"
            };

        }
       
    }
}
