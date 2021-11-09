using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        public int PositionId { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
