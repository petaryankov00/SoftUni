using CarCenter.ViewModels.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCenter.ViewModels.Cars
{
    public class CarInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Please enter a {0} between {2} and {1}")]
        public string Brand { get; set; }

        [Range(1900, 2022,ErrorMessage = "Please enter a {0} between {1} and {2}")]
        public int Year { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8,ErrorMessage = "Please enter valid plate number")]
        public string PlateNumber { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

        public IEnumerable<CategoryFormModel> Categories { get; set; }
    }

    
}
