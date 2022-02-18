using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCenter.Data.Models
{
    public class Car
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(8)]
        public string PlateNumber { get; set; }

        public int Year { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();


    }
}
