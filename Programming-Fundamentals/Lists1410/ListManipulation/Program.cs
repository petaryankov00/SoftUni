using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "Add")
                {
                    int num = int.Parse(command[1]);
                    numbers.Add(num);
                }
                else if (command[0] == "Remove")
                {
                    int num = int.Parse(command[1]);
                    numbers.Remove(num);
                }
                else if (command[0] == "RemoveAt")
                {
                    int num = int.Parse(command[1]);
                    numbers.RemoveAt(num);
                }
                else if (command[0] == "Insert")
                {
                    int num1 = int.Parse(command[1]);
                    int num2 = int.Parse(command[2]);
                    numbers.Insert(num2, num1);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ',numbers));
            
        }
    }
}
