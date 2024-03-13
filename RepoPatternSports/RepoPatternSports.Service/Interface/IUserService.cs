using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface IUserService
    {
        Task<ResponseDTO> GetUserById(int id);
        Task<bool> CheckCaptain(User user);

    }
}
