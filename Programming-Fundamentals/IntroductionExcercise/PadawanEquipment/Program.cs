using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLight = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalSumLights = priceOfLight * Math.Floor(countOfStudents * 1.1);
            double totalSumRobes = priceOfRobes * countOfStudents;
            double totalSumBelts = priceOfBelts * (countOfStudents - countOfStudents / 6);
            double totalPrice = totalSumBelts + totalSumLights + totalSumRobes;

            if (totalPrice <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");  
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice-amountOfMoney:f2}lv more.");
            }

        }
    }
}
