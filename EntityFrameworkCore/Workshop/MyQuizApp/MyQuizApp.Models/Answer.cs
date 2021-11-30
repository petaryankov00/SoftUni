using System.Collections.Generic;

namespace MyQuizApp.Models
{
    public class Answer
    {
        public Answer()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCorrect { get; set; }

        public int Points { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}