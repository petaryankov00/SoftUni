using CarShop.Models;
using CarShop.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;

        public IssuesController(IIssueService issueService)
        {
            this.issueService = issueService;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var issues = issueService.GetCarIssues(carId);

            return this.View(issues);
        }

        [Authorize]
        public HttpResponse Add(string carId)
           => this.View((object)carId);

        [HttpPost]
        [Authorize]
        public HttpResponse Add(IssueInputModel model)
        {
            var validateIssue = issueService.ValidateIssue(model);

            if (!validateIssue.isValid)
            {
                return View(validateIssue.Errors, "/Error");
            }

            issueService.AddIssue(model);

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");

        }

        public HttpResponse Delete(string issueId,string carId)
        {
            issueService.DeleteIssue(issueId, carId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            var isFixed = issueService.FixIssue(issueId, carId, this.User.Id);

            if (!isFixed)
            {
                return View(new List<string>() { "You are not a mechanic or issue is already fixed" }, "/Error");
            }

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
