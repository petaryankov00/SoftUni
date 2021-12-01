using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            Mails = new HashSet<Mail>();
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Range(18,65)]
        public int Age { get; set; }
    
        [Required]
        public DateTime IncarcerationDate  { get; set; }

        public DateTime? ReleaseDate { get; set; }


        public decimal? Bail { get; set; }

        public int? CellId { get; set; }
        public virtual Cell Cell { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }

        public virtual ICollection<OfficerPrisoner>  PrisonerOfficers  { get; set; }


    }
}