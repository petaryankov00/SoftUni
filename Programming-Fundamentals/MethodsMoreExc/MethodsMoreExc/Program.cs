using System;

namespace MethodsMoreExc
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input == "int")
            {
                int number = int.Parse(Console.ReadLine());
                TypeOfValue (number);
            }
            else if (input == "real")
            {
                double number = double.Parse(Console.ReadLine());
                TypeOfValue (number);
            }
            else if (input == "string")
            {
                string text = Console.ReadLine();
                TypeOfValue(text);
            }

        }
        static void TypeOfValue(int number)
        {
            int result = number * 2;
            Console.WriteLine(result);
        }
        static void TypeOfValue(double number)
        {
            double result = number * 1.5;
            Console.WriteLine($"{result:f2}");
        }
        static void TypeOfValue(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
