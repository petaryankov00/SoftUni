using System;

namespace ArraysMoreExc
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] array = new string[n];
            int[] values = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Console.ReadLine();
                int sumVowel = 0;
                int sumConstant = 0;
                foreach (char letter in array[i])               
                {
                   
                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o'
                        || letter == 'u' || letter == 'A' || letter == 'E' || letter == 'I'
                        || letter == 'O' || letter == 'U') 
                    {
                        sumVowel +=((int)letter * array[i].Length);
                    }
                    else
                    {
                        sumConstant += ((int)letter / array[i].Length);
                    }                   
                }
                int stringSum = sumVowel + sumConstant;
                values[i] = stringSum;
            }
            Array.Sort(values);
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
