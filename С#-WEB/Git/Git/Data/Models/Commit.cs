using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual User Creator { get; set; }

        public string RepositoryId { get; set; }

        [ForeignKey(nameof(RepositoryId))]
        public virtual Repository Repository { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object
