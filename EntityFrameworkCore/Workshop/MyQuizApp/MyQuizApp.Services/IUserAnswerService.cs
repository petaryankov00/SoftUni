using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string username,int questionId,int answerId);

        int GetUserResult(string username, int quizId);
    }
}
