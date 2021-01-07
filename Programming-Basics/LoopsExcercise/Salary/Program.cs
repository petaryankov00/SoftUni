using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabsCount = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());      

            for (int i = 1; i <= tabsCount; i++)
            {
                string tabs = Console.ReadLine();
                if (tabs == "Facebook")
                {
                    salary -= 150;
                }
                else if (tabs == "Instagram")
                {

                    salary -= 100;
                }
                else if (tabs == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {                   
                    break;
                }              
            }

            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else 
            {
                Console.WriteLine(salary);
            }

            

            
        }
    }
}
