using System.ComponentModel.DataAnnotations;

namespace Git.InputModels
{
    public class CreateUserInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} cannot be null or empty")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Password { get; set;}

        [Compare("Password", ErrorMessage = "Two passwords must be equal")]
        public string ConfirmPassword { get; set; }
    }
}
