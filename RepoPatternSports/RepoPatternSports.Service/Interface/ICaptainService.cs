using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface ICaptainService
    {
        Task<ResponseDTO> FormFinalTeam(int id);
        Task<List<User>> ViewTeam();
    }
}
