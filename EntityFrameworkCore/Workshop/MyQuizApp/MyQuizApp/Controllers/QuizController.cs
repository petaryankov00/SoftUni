using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyQuizApp.Services;

namespace MyQuizApp.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;
        private readonly IUserAnswerService userAnswerService;

        public QuizController(IQuizService quizService,IUserAnswerService userAnswerService)
        {
            this.quizService = quizService;
            this.userAnswerService = userAnswerService;
        }

        public IActionResult Test(int id)
        {
            this.quizService.StartQuiz(this.User.Identity.Name, id);
            var viewModel = this.quizService.GetQuizById(id);
            return View(viewModel);
        }

        public IActionResult Submit(int id)
        {
            foreach (var item in this.Request.Form)
            {
                var questionId = int.Parse(item.Key.Replace("q_", ""));
                var answerId = int.Parse(item.Value);
                this.userAnswerService.AddUserAnswer(this.User.Identity.Name,questionId,answerId);
            }

            return this.RedirectToAction("Results", new { id });
        }

        public IActionResult Results(int id)
        {
            var points = userAnswerService.GetUserResult(this.User.Identity.Name, id);
            return this.View(points);
        }


    }
}
