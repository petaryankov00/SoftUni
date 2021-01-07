using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int yearsOld = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double moneyToPay = 0;
            if (gender == "m")
            {
                if (sport == "Gym")
                {
                    moneyToPay = 42;
                }
                else if (sport == "Boxing")
                {
                    moneyToPay = 41;
                }
                else if (sport == "Yoga")
                {
                    moneyToPay = 45;
                }
                else if (sport == "Zumba")
                {
                    moneyToPay = 34;
                }
                else if (sport == "Dances")
                {
                    moneyToPay = 51;
                }
                else if (sport == "Pilates")
                {
                    moneyToPay = 39;
                }
            }

            if (gender == "f")
            {
                if (sport == "Gym")
                {
                    moneyToPay = 35;
                }
                else if (sport == "Boxing")
                {
                    moneyToPay = 37;
                }
                else if (sport == "Yoga")
                {
                    moneyToPay = 42;
                }
                else if (sport == "Zumba")
                {
                    moneyToPay = 31;
                }
                else if (sport == "Dances")
                {
                    moneyToPay = 53;
                }
                else if (sport == "Pilates")
                {
                    moneyToPay = 37;
                }
            }

            if (yearsOld <= 19)
            {
                moneyToPay = moneyToPay * 0.8;
            }
            else
            {
                moneyToPay = moneyToPay * 1;
            }
            if (money >= moneyToPay)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${moneyToPay-money:F2} more.");
            }
        }
    }
}
