using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface IValidationService
    {
        Task<ValidationErrorDTO> ValidateUser(RegisterDTO registerDTO);
    }
}
