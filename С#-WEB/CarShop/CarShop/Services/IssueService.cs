using CarShop.Data;
using CarShop.Data.Data.Models;
using CarShop.Models;
using CarShop.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly ApplicationDbContext dbContext;

        public IssueService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddIssue(IssueInputModel model)
        {
            var issues = new Issue
            {
                Description = model.Description,
                IsFixed = false,
                CarId = model.CarId
            };

            dbContext.Issues.Add(issues);
            dbContext.SaveChanges();
        }

        public (bool isValid, IEnumerable<string> Errors) ValidateIssue(IssueInputModel model)
        {
            var errors = new List<string>();
            bool isValid = true;

            if (model.Description == null || model.Description.Length < 5)
            {
                errors.Add("Invalid Description.");
                isValid = false;
            }

            return (isValid, errors);
        }

        public CarIssuesViewModel GetCarIssues(string carId)
        {
            var issues = dbContext
                .Cars
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel
                {
                    CarId = carId,
                    Model = $"{x.Year} {x.Model}",
                    Issues = x.Issues.Select(i => new IssuesViewModel
                    {
                        IssueId = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed == true ? "Yes" : "Not yet",
                    })
                    .ToList()
                })
                .FirstOrDefault();
                    

            return issues;
        }

        public void DeleteIssue(string issueId, string carId)
        {
            var issue = dbContext.Issues
                .Where(x => x.Id == issueId && x.CarId == carId)
                .FirstOrDefault();

            if (issue != null)
            {
                dbContext.Issues.Remove(issue);
                dbContext.SaveChanges();
            }
        }

        public bool FixIssue(string issueId, string carId, string userId)
        {
            var user = dbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (!user.IsMechanic)
            {
                return false;
            }

            var issue = dbContext
                .Issues
                .Where(x => x.Id == issueId && x.CarId == carId)
                .FirstOrDefault();

            if (issue.IsFixed)
            {
                return false;
            }


            issue.IsFixed = true;
            dbContext.SaveChanges();

            return true;
        }
    }
}
