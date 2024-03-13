using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface ICaptainService
    {
        Task<ResponseDTO> FormFinalTeam(int id);
        Task<List<User>> ViewTeam();
    }
}
