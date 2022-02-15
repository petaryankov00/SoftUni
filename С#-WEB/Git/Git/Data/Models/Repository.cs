using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type
