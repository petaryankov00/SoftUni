using System.ComponentModel.DataAnnotations;

namespace CarCenter.ViewModels.Issues
{
    public class IssueInputModel
    {
        [Required]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Description { get; set; }

        public string CarId { get; set; }
    }
}
