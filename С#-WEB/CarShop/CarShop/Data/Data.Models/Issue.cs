using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Data.Models
{
    public class Issue
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}