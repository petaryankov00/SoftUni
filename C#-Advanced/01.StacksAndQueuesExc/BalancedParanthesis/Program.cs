using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedParanthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> brackets = new Stack<char>();
            bool isValid = true;

            for (int i = 0; i < sequence.Length; i++)
            {
                char currBracket = sequence[i];
                if (currBracket == '{' || currBracket == '[' || currBracket == '(')
                {
                    brackets.Push(currBracket);
                }
                else
                {
                    char lastBracket = brackets.Pop();
                    if (currBracket == '}')
                    {
                        if (lastBracket == '{')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else if (currBracket == ']')
                    {
                        if (lastBracket == '[')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else if (currBracket == ')')
                    {
                        if (lastBracket == '(')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
           

        }
    }
}
