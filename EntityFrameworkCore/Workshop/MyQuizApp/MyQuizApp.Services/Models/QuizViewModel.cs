using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services.Models
{
    public class QuizViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<QuestionViewModel> AllQuestions { get; set; }
    }
}
