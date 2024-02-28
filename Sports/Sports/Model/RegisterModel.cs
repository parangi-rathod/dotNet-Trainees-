using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sports.Model
{
    public class RegisterModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [MinLength(8), MaxLength(14)]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public virtual Role role { get; set; }
    }
}
