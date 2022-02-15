using Git.InputModels;
using Git.Services.Contracts;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repositories = repositoryService.GetAllRepositories(this.User.Id);

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (User.IsAuthenticated)
            {
                return this.View();
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Create(RepostiryInputModel model)
        {
            (bool isValid,ErrorViewModel error) = repositoryService.CreateRepository(model, this.User.Id);

            if (!isValid)
            {
                return View(error, "/Error");
            }

            return Redirect("/Repositories/All");
        }
    }
}
