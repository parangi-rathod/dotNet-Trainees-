using System;
using System.ComponentModel.DataAnnotations;

namespace Sports.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 14 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public virtual Role Role { get; set; }
    }
}
