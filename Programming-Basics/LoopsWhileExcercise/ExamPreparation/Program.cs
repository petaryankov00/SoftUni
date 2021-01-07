using System;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int failedGrades = int.Parse(Console.ReadLine());
            string taskName = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            int counter = 0;
            if (grade <= 4)
            {
                counter++;
            }          
            double sumGrade = 0;
            int countGrades = 0;
            string lastTask = taskName;
            while (counter != failedGrades)
            {              
                sumGrade += grade;
                countGrades++;
                taskName = Console.ReadLine();
                if (taskName == "Enough")
                {
                    break;

                }
                grade = double.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    counter++;
                }
                lastTask = taskName;

            }
            if (counter == failedGrades)
            {
                Console.WriteLine($"You need a break, {counter} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {(sumGrade/countGrades):f2}");
                Console.WriteLine($"Number of problems: {countGrades}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}
