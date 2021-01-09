using System;

namespace FinalExam1312
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] cmdArgs = command.Split();
                switch (cmdArgs[0])
                {
                    case "Case":
                        if (cmdArgs[1] == "lower")
                        {
                            username = username.ToLower();
                            Console.WriteLine(username);
                        }
                        else
                        {
                            username = username.ToUpper();
                            Console.WriteLine(username);
                        }
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        if (startIndex >= 0 && endIndex < username.Length)
                        {
                            string part = username.Substring(startIndex, endIndex - startIndex+1);
                            char[] arr = part.ToCharArray();
                            Array.Reverse(arr);
                            string reversedPart = string.Join("", arr);
                            Console.WriteLine(reversedPart);                         
                        }
                        break;
                    case "Cut":
                        string substring = cmdArgs[1];
                        if (username.Contains(substring))
                        {
                            int index = username.IndexOf(substring);
                            int length = substring.Length;
                            username = username.Remove(index, length);
                            Console.WriteLine(username);                         
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {substring}.");
                        }
                        break;
                    case "Replace":
                        string letter = cmdArgs[1];
                        username = username.Replace(letter, "*");
                        Console.WriteLine(username);
                        break;
                    case "Check":
                        string validChar = cmdArgs[1];
                        if (username.Contains(validChar))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {validChar}.");
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
