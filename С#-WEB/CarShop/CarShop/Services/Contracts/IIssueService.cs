using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Services.Contracts
{
    public interface IIssueService
    {
        CarIssuesViewModel GetCarIssues(string carId);

        (bool isValid,IEnumerable<string> Errors) ValidateIssue(IssueInputModel model);

        void AddIssue(IssueInputModel model);

        void DeleteIssue(string issueId, string carId);

        bool FixIssue(string issueId ,string carId, string userId);
    }
}
