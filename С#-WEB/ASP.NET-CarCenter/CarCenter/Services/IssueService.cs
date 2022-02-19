using CarCenter.Data.Common;
using CarCenter.Data.Models;
using CarCenter.Services.Contracts;
using CarCenter.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCenter.Services
{
    public class IssueService : IIssueService
    {
        private readonly IRepository repo;

        public IssueService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddIssue(IssueInputModel model)
        {
            var issue = new Issue
            {
                CarId = model.CarId,
                Description = model.Description,
                IsFixed = false,
                CreatedOn = DateTime.UtcNow
            };

            repo.Add(issue);
            repo.SaveChanges();
        }

        public void FixIssue(string id)
        {
            var issue = repo.All<Issue>()
                .Where(i => i.Id == id)
                .FirstOrDefault();

            issue.IsFixed = true;
            repo.SaveChanges();
        }

        public IEnumerable<AllIssuesViewModel> GetAllIssues()
        {
            var issues = repo.All<Issue>()
                .OrderByDescending(x=>x.CreatedOn)
                .Select(x=> new AllIssuesViewModel
                {
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString("f"),
                    CarModel = x.Car.Brand.Name,
                    IsFixed = x.IsFixed == false ? "Not yet" : "Yes",
                    Id = x.Id
                })
                .ToList();

            return issues;
        }

        public IEnumerable<CarIssueViewModel> GetCarIssues(string id)
        {
            var issues = repo.All<Issue>()
                .Where(x => x.CarId == id)
                .Select(x => new CarIssueViewModel
                {
                    Description = x.Description,
                    IsFixed = x.IsFixed == false ? "Not yet" : "Yes",
                    CreatedOn = x.CreatedOn.ToString("f"),
                })
                .ToList();

            return issues;
        }
    }
}
