using System;
using System.Text;
using System.Linq;

namespace FinalExamPrep04AprilGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "TakeOdd":
                        StringBuilder password = new StringBuilder();
                        for (int i = 1; i < input.Length; i+=2)
                        {                         
                            password.Append(input[i]);
                            
                        }
                        input = password.ToString();
                        Console.WriteLine(input);
                        break;
                    case "Cut":
                        int index = int.Parse(cmdArgs[1]);
                        int length = int.Parse(cmdArgs[2]);
                        input = input.Remove(index, length);
                        Console.WriteLine(input);
                        break;
                    case "Substitute":
                        string toSub = cmdArgs[1];
                        string withThat = cmdArgs[2];
                        if (input.Contains(toSub))
                        {
                            input = input.Replace(toSub, withThat);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    default:
                        break;

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {input}");
            
        }
    }
}
