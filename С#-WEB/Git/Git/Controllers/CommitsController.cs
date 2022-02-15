using Git.InputModels;
using Git.Services.Contracts;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        public CommitsController(ICommitService commitService)
        {
            this.commitService = commitService;
        }

        public HttpResponse Create(string id)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var repo = commitService.GetCurrentRepository(id);

            return this.View(repo);
        }

        [HttpPost]
        public HttpResponse Create(CommitInputModel model)
        {

            var isValid = commitService.CreateCommit(model, this.User.Id);

            if (!isValid)
            {
                return View(new ErrorViewModel { Errors = { "Invalid description" } },"/Error");
            }

            return Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var commits = commitService.GetAllCommits(this.User.Id);

            return this.View(commits);
        }

        public HttpResponse Delete(string id)
        {
            var isDeleted = commitService.DeleteCommit(id,this.User.Id);
            if (!isDeleted)
            {
                return View(new ErrorViewModel { Errors = { "You cannot delete this commit" } }, "/Error");
            }

            return Redirect("/Commits/All");
        }
    }
}
