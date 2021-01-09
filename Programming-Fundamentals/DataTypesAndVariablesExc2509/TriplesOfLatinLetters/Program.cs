using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int firstSymbol = 0; firstSymbol < n ; firstSymbol++)
            {
                for (int secondSymbol = 0; secondSymbol < n; secondSymbol++)
                {
                    for (int thirdSymbol  = 0; thirdSymbol < n; thirdSymbol++)
                    {
                        char firstChar = (char)(97 + firstSymbol);
                        char secondChar = (char)(97 + secondSymbol);
                        char thirdChar = (char)(97 + thirdSymbol);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
