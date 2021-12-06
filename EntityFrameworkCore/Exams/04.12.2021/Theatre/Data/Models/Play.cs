﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Tickets = new HashSet<Ticket>();
            Casts = new HashSet<Cast>();    
        }

        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "c", ApplyFormatInEditMode = true)]
        public TimeSpan Duration { get; set; }

        [Range(0.00,10.00)]
        [Required]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public  string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } 
    }
}
