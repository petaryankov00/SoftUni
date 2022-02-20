using FootballManager.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(DataConstants.User.NameMaxLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(DataConstants.User.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
