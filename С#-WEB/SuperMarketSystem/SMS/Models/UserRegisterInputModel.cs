using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class UserRegisterInputModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
