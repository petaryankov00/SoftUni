using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportModel
    {
        [MinLength(3),MaxLength(30)]
        [Required]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^(The)\s([A-Z][a-z]+)$")]
        public string Nickname { get; set; }

        [Range(18,65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }
    
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailImportModel[] Mails { get; set; }
    }

    public class MailImportModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }
        [Required]
        [RegularExpression(@"^([A-Za-z0-9\s]+)(str\.)$")]
        public string Address { get; set; }
    }
}
