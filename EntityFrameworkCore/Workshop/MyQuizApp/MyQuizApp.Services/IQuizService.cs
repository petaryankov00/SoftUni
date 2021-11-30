using MyQuizApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services
{
    public interface IQuizService
    {
        int Add(string title);

        QuizViewModel GetQuizById(int id);

        IEnumerable<UserQuizViewModel> GetQuizesByUsername(string username);

        void StartQuiz(string username,int quizId);
    }
}
