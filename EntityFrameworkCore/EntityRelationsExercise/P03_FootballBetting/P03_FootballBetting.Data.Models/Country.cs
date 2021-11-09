using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        public int CountryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
