using FootballManager.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Player.NameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(DataConstants.Player.PositionMaxLength)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [StringLength(DataConstants.Player.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
