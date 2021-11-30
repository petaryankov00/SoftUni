using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services
{
    public interface IQuestionService
    {
        int Add(string title,int quizId);
    }
}
