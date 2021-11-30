namespace MyQuizApp.ConsoleUI
{
    public class JsonObjectImport
    {
        public string Question { get; set; }

        public AnswerInputModel[] Answers { get; set; }

    }

    public class AnswerInputModel
    {
        public string Answer { get; set; }

        public bool Correct { get; set; }

    }
}
