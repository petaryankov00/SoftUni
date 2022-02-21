using CarCenter.Models;
using CarCenter.Services.Contracts;
using CarCenter.ViewModels.Issues;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarCenter.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;

        public IssuesController(IIssueService issueService)
        {
            this.issueService = issueService;
        }

        [Authorize]
        public IActionResult Add(string id)
        {
            var issue = new IssueInputModel { CarId = id };
            return View(issue);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(IssueInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var issue = new IssueInputModel { CarId = model.CarId };
                return View(issue);
            }
            try
            {
                issueService.AddIssue(model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message });
            }

            return Redirect("/Issues/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var issues = issueService.GetAllIssues();

            return this.View(issues);
        }

        [Authorize]
        public IActionResult CarIssues(string id)
        {
            var issues = issueService.GetCarIssues(id);
            return View(issues);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult FixIssue(string id)
        {
            issueService.FixIssue(id);

            return Redirect("/Issues/All");
        }
    }

}
