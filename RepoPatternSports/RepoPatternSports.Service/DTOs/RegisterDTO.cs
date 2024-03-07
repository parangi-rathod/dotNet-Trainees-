using RepoPatternSports.Repository.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RepoPatternSports.Repository.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string Lastname { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; } = "team1234";

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be a 10-digit number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [Range(1, 3, ErrorMessage = "User can either register as Coach or as Player")]
        public Role role { get; set; }
    }
}
