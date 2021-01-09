using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(@"\");
            string lastElement = input[input.Length - 1];
            string[] mass = lastElement.Split(".");
            Console.WriteLine($"File name: {mass[0]}");
            Console.WriteLine($"File extension: {mass[1]}");
        }
    }
}
