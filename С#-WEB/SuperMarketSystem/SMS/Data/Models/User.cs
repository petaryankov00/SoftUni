using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual Cart Cart { get; set; }
        public string CartId { get; set; }

    }
}
