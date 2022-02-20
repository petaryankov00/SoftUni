using FootballManager.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Users
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(DataConstants.User.NameMaxLength, 
                      MinimumLength = DataConstants.User.NameMinLength,
                      ErrorMessage = "{0} must be between {2} and {1}")]
        public string Username { get; set; }

        [Required]
        [StringLength(DataConstants.User.EmailMaxLength,
                      MinimumLength = DataConstants.User.EmailMinLength,
                      ErrorMessage = "{0} must be between {2} and {1}")]
        public string Email { get; set; }

        [Required]
        [StringLength(DataConstants.User.PasswordMaxLength,
                      MinimumLength = DataConstants.User.PasswordMinLength,
                      ErrorMessage = "{0} must be between {2} and {1}")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Two passwords must be equal")]
        public string ConfirmPassword { get; set; }
    }
}
