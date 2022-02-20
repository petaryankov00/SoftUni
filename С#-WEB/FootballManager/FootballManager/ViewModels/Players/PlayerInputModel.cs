using FootballManager.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Players
{
    public class PlayerInputModel
    {
        [Required]
        [StringLength(DataConstants.Player.NameMaxLength,
                      MinimumLength = DataConstants.Player.NameMinLength,
                      ErrorMessage = "{0} must be between {2} and {1}")]
        public string FullName { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(DataConstants.Player.PositionMaxLength,
                      MinimumLength = DataConstants.Player.PositionMinLength,
                      ErrorMessage = "{0} must be between {2} and {1}")]
        public string Position { get; set; }

        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}")]
        public int Speed { get; set; }

        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}")]
        public int Endurance { get; set; }

        [Required]
        [StringLength(DataConstants.Player.DescriptionMaxLength, 
                      ErrorMessage = "{0} cannot be greater than {1}")]
        public string Description { get; set; }
    }
}
