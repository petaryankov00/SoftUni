using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserInputModel
    {     
        [RegularExpression(@"^[A-Z][a-z]*\s{1}[A-Z][a-z]*$")]
        [Required]
        public string FullName { get; set; }

        [MinLength(3), MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        public ICollection<InputModelCard> Cards { get; set; }

    }

    public class InputModelCard
    {
        [Required]
        [RegularExpression(@"[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        public CardType Type { get; set; }
    }
}
