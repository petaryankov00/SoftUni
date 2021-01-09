using System;

namespace DataTypesAndVariablesExc2509
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());
            int thirdInteger = int.Parse(Console.ReadLine());
            int fourthInteger = int.Parse(Console.ReadLine());
            int sumFirstAndSecond = firstInteger + secondInteger;
            int devideByThird = sumFirstAndSecond / thirdInteger;
            int multiplyByFourth = devideByThird * fourthInteger;
            Console.WriteLine(multiplyByFourth);
        }
    }
}
