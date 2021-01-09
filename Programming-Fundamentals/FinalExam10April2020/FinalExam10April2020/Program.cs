using System;
using System.Linq;

namespace FinalExam10April2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:",StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "InsertSpace":
                       input = input.Insert(int.Parse(cmdArgs[1])," ");
                        Console.WriteLine(input);
                        break;
                    case "Reverse":
                        if (input.Contains(cmdArgs[1]))
                        {
                            int index = input.IndexOf(cmdArgs[1]);                           
                            string part  = input.Substring(index,cmdArgs[1].Length);
                            input = input.Remove(index, cmdArgs[1].Length);
                            char[] arr = part.ToCharArray();
                            Array.Reverse(arr);
                            string reversedPart = string.Join("", arr);
                            input = input.Insert(input.Length, reversedPart);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        if (input.Contains(cmdArgs[1]))
                        {
                            input = input.Replace(cmdArgs[1], cmdArgs[2]);
                        }                      
                        Console.WriteLine(input);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
