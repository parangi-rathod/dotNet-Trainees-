using RepoPatternSports.Repository.Models;
using System.ComponentModel.DataAnnotations;

namespace RepoPatternSports.Repository.DTOs
{
    public class RegisterDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public Role role { get; set; }
    }
}
