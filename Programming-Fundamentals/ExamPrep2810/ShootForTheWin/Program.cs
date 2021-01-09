using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();
            string input = Console.ReadLine();
            int shotTargets = 0;

            while (input != "End")
            {
                int index = int.Parse(input);
                if (index < 0 || index >= numbers.Length)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (numbers[index] == -1)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == -1 || index==i)
                        {
                            continue;
                        }
                        if (numbers[index] < numbers[i])
                        {
                            numbers[i] -= numbers[index];
                        }
                        else
                        {
                            numbers[i] += numbers[index];
                        }                       
                    }
                    numbers[index] = -1;
                    shotTargets++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ",numbers)}");
        }
    }
}
