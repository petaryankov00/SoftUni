using System.Collections.Generic;

namespace MyQuizApp.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}