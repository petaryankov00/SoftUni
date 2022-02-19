using System;
using System.ComponentModel.DataAnnotations;

namespace CarCenter.Data.Models
{
    public class Issue
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }
        
    }
}
