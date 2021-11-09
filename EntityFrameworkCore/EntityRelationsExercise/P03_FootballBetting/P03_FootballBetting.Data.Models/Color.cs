using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            PrimaryKitTeams = new HashSet<Team>();
            SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        [InverseProperty("SecondaryKitColor")]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
