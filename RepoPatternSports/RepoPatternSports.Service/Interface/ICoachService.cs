using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface ICoachService
    {
        Task<ResponseDTO> AssignCaptain(int id);
        Task<ResponseDTO> AddPlayerToTeam(int id);
        Task<List<User>> ViewTeam();



    }
}
