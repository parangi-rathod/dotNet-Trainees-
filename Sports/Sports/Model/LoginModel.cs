using System.ComponentModel.DataAnnotations;

namespace Sports.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "Password is required")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 14 characters")]
        public string Password { get; set; }
    }
}
