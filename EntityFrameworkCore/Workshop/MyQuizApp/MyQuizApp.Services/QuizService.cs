using MyQuizApp.Data;
using MyQuizApp.Models;
using MyQuizApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MyQuizApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext dbContext;

        public QuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public int Add(string title)
        {
            var quiz = new Quiz
            {
                Title = title,
            };

            this.dbContext.Quizes.AddAsync(quiz);

            this.dbContext.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int id)
        {
            
            var quiz = dbContext.Quizes
                .Where(x=>x.Id == id)
                .OrderBy(r => Guid.NewGuid())
                .Select(x=> new QuizViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    AllQuestions = x.Questions
                    .Select(y => new QuestionViewModel
                    {
                        Title = y.Title,
                        Id = y.Id,
                        Answers = y.Answers.OrderBy(r => Guid.NewGuid())
                        .Select(a => new AnswerViewModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                        })
                    })
                }).
                FirstOrDefault();


            return quiz;
        }

        public IEnumerable<UserQuizViewModel> GetQuizesByUsername(string username)
        {
            var quizes = dbContext.Quizes
                .Select(x => new UserQuizViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                }).ToList();

            foreach (var quiz in quizes)
            {
                var countQuestions = dbContext.UserAnswers
                    .Count(x=>x.IdentityUser.UserName == username 
                     && x.Question.QuizId == quiz.Id);

                if (countQuestions == 0)
                {
                    quiz.Status = QuizStatus.NotSstarted;
                    continue;
                }

                var answeredQuestions = dbContext.UserAnswers
                    .Count(x => x.IdentityUser.UserName == username                                                          
                     && x.Question.QuizId == quiz.Id && x.AnswerId.HasValue);

                if (answeredQuestions == countQuestions)
                {
                    quiz.Status = QuizStatus.Finished;
                }
                else
                {
                    quiz.Status = QuizStatus.Progress;
                }

            }

            return quizes;
        }

        public void StartQuiz(string username, int quizId)
        {
            if (dbContext.UserAnswers
                .Any(x=>x.IdentityUser.UserName == username
            && x.Question.QuizId == quizId))
            {
                return;
            }

            var questions = dbContext.Questions.Where(x => x.QuizId == quizId).Select(x => x.Id).ToList();
            var userId = dbContext.Users.Where(x=>x.UserName == username).Select(x => x.Id).FirstOrDefault();
            foreach (var question in questions)
            {
                dbContext.UserAnswers.Add(new UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question
                });
            }

            dbContext.SaveChanges();
        }
    }
}
