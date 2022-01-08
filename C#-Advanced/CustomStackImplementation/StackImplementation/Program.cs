using System;
using System.Collections.Generic;
using System.Linq;

namespace StackImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            
            stack.ForEach(x=> Console.WriteLine(x));

         
            
        }
    }
}
