using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmdArgs = command.Split();
                string firstArg = cmdArgs[0];
                if (cmdArgs[0] == "add")
                {
                    int firstNumber = int.Parse(cmdArgs[1]);
                    int secondNumber = int.Parse(cmdArgs[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (cmdArgs[0] == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
