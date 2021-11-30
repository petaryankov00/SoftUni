using MyQuizApp.Data;
using MyQuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyQuizApp.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public UserAnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
   
        public void AddUserAnswer(string username, int questionId, int answerId)
        {
            var userId = dbContext.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            var userAnswer = this.dbContext.UserAnswers.FirstOrDefault(x => x.IdentityUserId == userId && x.QuestionId == questionId);

            userAnswer.AnswerId = answerId;
         
            this.dbContext.SaveChanges(); 
        }

        public int GetUserResult(string username, int quizId)
        {
            var userId = dbContext.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();

            int? userResult = dbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);

            return userResult.GetValueOrDefault();

            //var quizDb = this.dbContext.Quizes
            //    .Include(x=> x.Questions)
            //    .ThenInclude(x=> x.Answers)
            //    .FirstOrDefault(x=>x.Id == quizId);

            //var userAnswers = this.dbContext.UserAnswers
            //    .Where(x=>x.IdentityUserId == userId && x.Question.QuizId == quizId)
            //    .ToList();

            //int? totalPoints = 0;

            //foreach (var userAnswer in userAnswers)
            //{
            //    totalPoints += quizDb.Questions
            //        .FirstOrDefault(x => x.Id == userAnswer.QuestionId)
            //        .Answers
            //        .Where(x => x.IsCorrect == true)
            //        .FirstOrDefault(x => x.Id == userAnswer.AnswerId)
            //        .Points;

            //}
        }
    }
}
