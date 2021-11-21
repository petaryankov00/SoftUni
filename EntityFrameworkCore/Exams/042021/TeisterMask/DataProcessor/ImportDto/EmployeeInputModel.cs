using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeInputModel
    {
        [MaxLength(40),MinLength(3)]        
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]{3,}$")]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        [Required]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }


    }
}
