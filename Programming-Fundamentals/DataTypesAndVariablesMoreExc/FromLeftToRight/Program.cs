using System;
using System.Numerics;

namespace FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            //25/100...
            int lineNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineNumbers; i++)
            {
                string numbers = Console.ReadLine();

                string firstNumberAssString = string.Empty;
                string secondNumberAssString = string.Empty;

                bool isFirstNumberFound = false;

                for (int j = 0; j < numbers.Length; j++)
                {
                    char currentDigit = numbers[j];

                    if (isFirstNumberFound == false)
                    {
                        if (currentDigit == ' ')
                        {
                            isFirstNumberFound = true;
                        }
                        else
                        {
                            firstNumberAssString += numbers[j];
                        }
                    }
                    else
                    {
                        secondNumberAssString += currentDigit;
                    }
                }

                BigInteger num1 = BigInteger.Parse(firstNumberAssString);
                BigInteger num2 = BigInteger.Parse(secondNumberAssString);

                BigInteger digit1 = 0;
                BigInteger sum1 = 0;
                while (num1 > 0)
                {
                    digit1 = num1 % 10;
                    num1 = num1 / 10;
                    sum1 = sum1 + digit1;

                }

                BigInteger digit2 = 0;
                BigInteger sum2 = 0;
                while (num2 > 0)
                {
                    digit2 = num2 % 10;
                    num2 = num2 / 10;
                    sum2 = sum2 + digit2;
                }

                if (sum1 > sum2)
                {
                    Console.WriteLine($"{sum1}");
                }

                else if (sum2 > sum1)
                {
                    Console.WriteLine($"{sum2}");
                }
                else
                {
                    Console.WriteLine($"{sum1}");
                }
            }
        }
    }
}
