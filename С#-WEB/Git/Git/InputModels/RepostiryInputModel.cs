using System.ComponentModel.DataAnnotations;

namespace Git.InputModels
{
    public class RepostiryInputModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3,ErrorMessage = "{0} must be between {2} and {1}")]
        public string Name { get; set; }

        [Required]
        public string RepositoryType { get; set; }
    }
}
