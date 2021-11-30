using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Services.Models
{
    public class UserQuizViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public QuizStatus Status { get; set; }
    }

    public enum QuizStatus
    {
        NotSstarted = 1,
        Progress = 2,
        Finished = 3
    }
}
