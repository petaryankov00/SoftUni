using Git.Data;
using Git.Data.Models;
using Git.InputModels;
using Git.Services.Contracts;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext dbContext;
        public CommitService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateCommit(CommitInputModel model,string userId)
        {
            if (model.Description == null || model.Description.Length < 5)
            {
                return false;
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatorId = userId,
                CreatedOn = DateTime.Now,
                RepositoryId = model.Id
            };

            dbContext.Commits.Add(commit);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCommit(string id, string userId)
        {
            var commit = dbContext.Commits.FirstOrDefault(x => x.Id == id);
            if (commit.CreatorId != userId)
            {
                return false;
            }
            dbContext.Commits.Remove(commit);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<AllCommitsViewModel> GetAllCommits(string userId)
        {
            var commits = dbContext
                .Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new AllCommitsViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy hh:mm"),
                    RepositoryName = x.Repository.Name
                })
                .ToList();

            return commits;
                
        }

        public CreateCommitViewModel GetCurrentRepository(string repositoryId)
        {
            var repository = dbContext.Repositories
                .Where(x => x.Id == repositoryId)
                .Select(x => new CreateCommitViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefault();

            return repository;
        }
    }
}
