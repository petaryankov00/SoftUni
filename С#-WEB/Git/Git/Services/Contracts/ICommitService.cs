using Git.InputModels;
using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.Contracts
{
    public interface ICommitService
    {
        CreateCommitViewModel GetCurrentRepository(string repositoryId);

        bool CreateCommit(CommitInputModel model, string userId);

        IEnumerable<AllCommitsViewModel> GetAllCommits(string userId);

        bool DeleteCommit(string id, string userId);
    }
}
