using System;
using System.Linq;

namespace MaxSeqOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int bestCount = 0;
            int bestIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                string currentElement = array[i];
                int counter = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentElement == array[j])
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (counter > bestCount)
                {
                    bestCount = counter;
                    bestIndex = i;
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write($"{array[bestIndex]} ");
            }
                        
        }
    }
}
