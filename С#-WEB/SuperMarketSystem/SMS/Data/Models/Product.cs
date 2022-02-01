using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual Cart Cart { get; set; }
        public string CartId { get; set; }


    }
}
