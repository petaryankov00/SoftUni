using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }



    }
}
