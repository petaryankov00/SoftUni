using System;

namespace Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int clas = 1;
            int breakclas = 0;
            double totalSum = 0;
            while (clas <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4 )
                {
                    breakclas++;
                    
                }
                else if (grade >=4)
                {
                    clas++;
                    totalSum += grade;
                }
                if (breakclas > 1)
                {
                    break;
                }               
            }
            if (breakclas > 1)
            {
                Console.WriteLine($"{name} has been excluded at {clas} grade");
            }
            else
            {
                double averageSum = totalSum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageSum:f2}");
               
            }
         
        }
    }
}
