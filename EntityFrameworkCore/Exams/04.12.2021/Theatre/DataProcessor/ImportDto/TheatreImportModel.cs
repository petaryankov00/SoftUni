using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheatreImportModel
    {
        [Required]
        [MinLength(4),MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(4), MaxLength(30)]
        public string Director { get; set; }

        public TicketImportModel[] Tickets { get; set; }
    }

    public class TicketImportModel
    {
        [Range(1.00,100.00)]
        [Required]
        public decimal Price { get; set; }

        [Range(1,10)]
        [Required]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
