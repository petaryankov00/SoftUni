using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToList();
            int[] bombProp = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();
            int bomb = bombProp[0];
            int bombPower = bombProp[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber == bomb)
                {
                    int startIndex = i - bombPower;
                    int endIndex = i + bombPower;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > numbers.Count-1)
                    {
                        endIndex = numbers.Count - 1;
                    }
                    int elementsToRemove = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, elementsToRemove);
                    i = startIndex - 1;
                }
            }
            Console.WriteLine(numbers.Sum()); 

        }
    }
}
