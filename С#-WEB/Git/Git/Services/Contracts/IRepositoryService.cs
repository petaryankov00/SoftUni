using Git.InputModels;
using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.Contracts
{
    public interface IRepositoryService
    {
        IEnumerable<RepositoryViewModel> GetAllRepositories(string userId);

        (bool isValid, ErrorViewModel error) CreateRepository(RepostiryInputModel model,string userId);
    }
}
