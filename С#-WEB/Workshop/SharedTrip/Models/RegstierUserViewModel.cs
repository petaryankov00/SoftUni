using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class RegstierUserViewModel
    {
        public string Username { get; init; }

        public string Email { get; init; }
        
        public string Password { get; init; }

        public string ConfirmPassword { get; init; }
    }
}
