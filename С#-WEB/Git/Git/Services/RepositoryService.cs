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
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IValidationService validationService;

        public RepositoryService(ApplicationDbContext dbContext,IValidationService validationService)
        {
            this.dbContext = dbContext;
            this.validationService = validationService;
        }

        public (bool isValid, ErrorViewModel error) CreateRepository(RepostiryInputModel model, string userId)
        {
            (bool isValid, ErrorViewModel error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (false, error);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                CreatedOn = DateTime.Now,
                OwnerId = userId
            };

            dbContext.Repositories.Add(repository);
            dbContext.SaveChanges();

            return (true, error);
        }

        public IEnumerable<RepositoryViewModel> GetAllRepositories(string userId)
        {
            var repositories = dbContext.Repositories
                .Where(x => x.IsPublic == true || x.OwnerId == userId)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CommitsCount = x.Commits.Count,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy hh:mm")
                })
                .ToList();

            return repositories;
        }
    }
}
