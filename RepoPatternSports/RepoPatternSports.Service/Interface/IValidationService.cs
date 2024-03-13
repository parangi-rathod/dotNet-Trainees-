using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface IValidationService
    {
        Task<ValidationErrorDTO> ValidateUser(RegisterDTO registerDTO);
    }
}
