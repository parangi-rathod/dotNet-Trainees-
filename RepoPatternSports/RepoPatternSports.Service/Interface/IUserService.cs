using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface IUserService
    {
        Task<ResponseDTO> GetUserById(int id);
        Task<bool> CheckCaptain(User user);

    }
}
