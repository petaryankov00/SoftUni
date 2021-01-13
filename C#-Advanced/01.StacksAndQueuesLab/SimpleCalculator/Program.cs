using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> expression = new Stack<string>();
            
            for (int i = input.Length-1; i >= 0; i--)
            {
                expression.Push(input[i]);
            }
            while (expression.Count > 1)
            {
                int leftNumber = int.Parse(expression.Pop());
                string operatorSign = expression.Pop();
                int rightNumber = int.Parse(expression.Pop());

                if (operatorSign == "+")
                {
                    expression.Push((leftNumber + rightNumber).ToString());
                }
                else if (operatorSign == "-")
                {
                    expression.Push((leftNumber - rightNumber).ToString());
                }
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
