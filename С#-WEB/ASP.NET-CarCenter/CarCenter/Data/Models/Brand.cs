using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCenter.Data.Models
{
    public class Brand
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}