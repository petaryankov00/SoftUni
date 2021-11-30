using MyQuizApp.Data;
using MyQuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public AnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string title, int questionId, int points, bool isCorrect)
        {
            var answer = new Answer
            {
                Title = title,
                QuestionId = questionId,
                Points = points,
                IsCorrect = isCorrect
            };

            this.dbContext.Answers.Add(answer);
            this.dbContext.SaveChanges();

            return answer.Id;
        }
    }
}
