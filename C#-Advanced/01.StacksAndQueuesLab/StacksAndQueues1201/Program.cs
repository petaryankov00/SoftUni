using System;
using System.Collections.Generic;

namespace StacksAndQueues1201
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> books = new Stack<string>();
            books.Push("Pinokio");
            books.Push("War and peace");
            books.Push("Alhimikyt");
            Console.WriteLine(books.Pop());
        }
    }
}
