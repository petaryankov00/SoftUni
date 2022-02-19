using CarCenter.ViewModels.Issues;
using System.Collections.Generic;

namespace CarCenter.Services.Contracts
{
    public interface IIssueService
    {
        void AddIssue(IssueInputModel model);

        IEnumerable<AllIssuesViewModel> GetAllIssues();

        IEnumerable<CarIssueViewModel> GetCarIssues(string id);

        void FixIssue(string id);
    }
}
