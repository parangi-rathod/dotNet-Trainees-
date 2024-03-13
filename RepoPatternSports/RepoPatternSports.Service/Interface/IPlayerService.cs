using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface IPlayerService
    {
        Task<ResponseDTO> GetCaptain();
        Task<object> GetCoach();
    }
}
