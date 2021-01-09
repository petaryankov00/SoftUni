using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArg = command.Split().ToArray();
                string firstCommand = cmdArg[0];
                int secondCommand = int.Parse(cmdArg[1]);
                if (firstCommand == "Delete")
                {
                    numbers.RemoveAll(x=> x == secondCommand);
                }
                else if (firstCommand == "Insert")
                {
                    int thirdCommand = int.Parse(cmdArg[2]);
                    numbers.Insert(thirdCommand, secondCommand);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));


        }
    }
}
