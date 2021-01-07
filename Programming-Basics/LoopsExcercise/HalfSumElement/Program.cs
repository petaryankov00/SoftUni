using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumNumber = 0;
            int max = int.MinValue;

            for (int i = 1; i <= input; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sumNumber += num;
                if (num > max)
                {
                    max = num;
                }
                
            }
            int sumNumberWithoutMax = sumNumber - max;

            if (sumNumberWithoutMax == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max - sumNumberWithoutMax)}");          
            }
            
        }
    }
}
