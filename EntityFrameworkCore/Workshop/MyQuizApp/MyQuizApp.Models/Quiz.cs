using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
