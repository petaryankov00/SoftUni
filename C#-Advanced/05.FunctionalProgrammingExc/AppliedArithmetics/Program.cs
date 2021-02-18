using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Action<int[]> print = (arr =>
            {
                Console.WriteLine(string.Join(" ", numbers));
            });

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[], int[]> func = GetProccesor(input);
                    numbers = func(numbers);
                }
                input = Console.ReadLine();
            }
        }
        static Func<int[], int[]> GetProccesor(string input)
        {
            Func<int[], int[]> proccesor = null;
            if (input == "add")
            {
                proccesor = new Func<int[], int[]>(arr =>
                {
                    return arr.Select(n => n + 1).ToArray();
                });
            }
            else if (input == "multiply")
            {
                proccesor = new Func<int[], int[]>(arr =>
                {
                    return arr.Select(n => n * 2).ToArray();
                });
            }
            else if (input == "subtract")
            {
                proccesor = new Func<int[], int[]>(arr =>
                {
                    return arr.Select(n => n - 1).ToArray();
                });
            }
            return proccesor;
        }

    }
}
