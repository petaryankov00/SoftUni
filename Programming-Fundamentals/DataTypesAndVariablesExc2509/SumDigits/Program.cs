using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                // convert char to string
                int currentNumber = (int)Char.GetNumericValue(input[i]);
                // OR int currentNumber = int.Pasre(input[i].ToString())          
                sum += currentNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
