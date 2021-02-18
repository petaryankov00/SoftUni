using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] evenNumbers = array.Where(x => x % 2 == 0).OrderBy(n => n).ToArray();
            Console.WriteLine(string.Join(", ",evenNumbers));
        }
    }
}
