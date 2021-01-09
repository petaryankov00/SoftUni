using System;
using System.Xml;

namespace FinalExam09August
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "Add Stop":
                        int index = int.Parse(cmdArgs[1]);
                        if (index >= 0 && index < input.Length)
                        {
                            input = input.Insert(index, cmdArgs[2]);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine(input);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        if (startIndex >= 0 && startIndex < input.Length
                            && endIndex >= 0 && endIndex < input.Length)
                        {
                            input = input.Remove(startIndex, endIndex - startIndex+1);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine(input);
                        }
                        break;
                    case "Switch":
                        if (input.Contains(cmdArgs[1]))
                        {
                            input = input.Replace(cmdArgs[1], cmdArgs[2]);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine(input);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
