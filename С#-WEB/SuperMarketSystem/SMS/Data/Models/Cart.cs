using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Cart
    { 
        public Cart()
        {
            Products = new HashSet<Product>();  
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
