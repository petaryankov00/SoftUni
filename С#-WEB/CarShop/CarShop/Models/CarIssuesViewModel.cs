using System.Collections.Generic;

namespace CarShop.Models
{
    public class CarIssuesViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public IEnumerable<IssuesViewModel> Issues { get; set; }

    }

    public class IssuesViewModel
    {
        public string IssueId { get; set; }
        public string Description { get; set; }

        public string IsFixed { get; set; }
    }
}
