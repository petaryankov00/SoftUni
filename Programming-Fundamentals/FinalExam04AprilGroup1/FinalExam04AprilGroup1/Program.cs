using System;
using System.Text;

namespace FinalExam04AprilGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] cmdArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);               
                switch (cmdArgs[0])
                {
                    case "Contains":
                        if (activationKey.IndexOf(cmdArgs[1]) != -1)
                        {
                            Console.WriteLine($"{activationKey} contains {cmdArgs[1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(cmdArgs[2]);
                        int endIndex = int.Parse(cmdArgs[3]);
                        string firstPart = activationKey.Substring(0, startIndex);
                        string secondPart = activationKey.Substring(startIndex, endIndex - startIndex);
                        string thirdPart = activationKey.Substring(endIndex);
                        if (cmdArgs[1].ToUpper() == "UPPER")
                        {
                            secondPart = secondPart.ToUpper();
                        }
                        else
                        {
                            secondPart = secondPart.ToLower();
                        }
                        activationKey = firstPart + secondPart + thirdPart;
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(cmdArgs[1]);
                        endIndex = int.Parse(cmdArgs[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();               
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
