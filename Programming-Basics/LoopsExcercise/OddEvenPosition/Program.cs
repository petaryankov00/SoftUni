using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double OddSum = 0;
            double OddMax = int.MinValue;
            double OddMin = int.MaxValue;
            double EvenSum = 0;
            double EvenMax = int.MinValue;
            double EvenMin = int.MaxValue;


            for (int i = 1; i <= n; i++)
            {
                double numbers = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    EvenSum += numbers;
                    if (numbers > EvenMax)
                    {
                        EvenMax = numbers;
                    }
                    if (numbers < EvenMin)
                    {
                        EvenMin = numbers;
                    }
                }
                else
                {
                    OddSum += numbers;
                    if (numbers > OddMax)
                    {
                        OddMax = numbers;
                    }
                    if (numbers < OddMin)
                    {
                        OddMin = numbers;
                    }
                }
            }
                if (n == 1)
                {
                    Console.WriteLine($"OddSum={OddSum:F2},");
                    Console.WriteLine($"OddMin={OddMin:F2},");
                    Console.WriteLine($"OddMax={OddMax:F2},");
                    Console.WriteLine($"EvenSum={EvenSum:F2},");
                    Console.WriteLine("EvenMin=No,");
                    Console.WriteLine("EvenMax=No");
                }
                else if (n == 0)
                {
                    Console.WriteLine($"OddSum={OddSum:F2},");
                    Console.WriteLine("OddMin=No,");
                    Console.WriteLine("OddMax=No,");
                    Console.WriteLine($"EvenSum={EvenSum:F2},");
                    Console.WriteLine("EvenMin=No,");
                    Console.WriteLine("EvenMax=No");
                }
                else
                {
                    Console.WriteLine($"OddSum={OddSum:F2},");
                    Console.WriteLine($"OddMin={OddMin:F2},");
                    Console.WriteLine($"OddMax={OddMax:F2},");
                    Console.WriteLine($"EvenSum={EvenSum:F2},");
                    Console.WriteLine($"EvenMin={EvenMin:F2},");
                    Console.WriteLine($"EvenMax={EvenMax:F2}");
                }


                

            

        }
    }
}
