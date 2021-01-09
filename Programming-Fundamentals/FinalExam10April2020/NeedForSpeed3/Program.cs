using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> cars = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string name = currCar[0];
                int miles = int.Parse(currCar[1]);
                int fuel = int.Parse(currCar[2]);
                cars.Add(name, new Dictionary<string, int>
                {
                    {"mileage",miles },
                    {"fuel",fuel }
                });
            }
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string car = cmdArgs[1];
                switch (cmdArgs[0])
                {
                    case "Drive":
                        int distance = int.Parse(cmdArgs[2]);
                        int needFuel = int.Parse(cmdArgs[3]);
                        if (needFuel > cars[car]["fuel"])
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[car]["fuel"] -= needFuel;
                            cars[car]["mileage"] += distance;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {needFuel} liters of fuel consumed.");
                        }
                        if (cars[car]["mileage"] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                        break;
                    case "Refuel":
                        int fuel = int.Parse(cmdArgs[2]);
                        cars[car]["fuel"] += fuel;
                        if (cars[car]["fuel"] > 75)
                        {
                            fuel = fuel - (cars[car]["fuel"] - 75);
                            cars[car]["fuel"] = 75;
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }
                        else
                        {
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }
                        break;
                    case "Revert":
                        int kilometers = int.Parse(cmdArgs[2]);
                        cars[car]["mileage"] -= kilometers;
                        if (cars[car]["mileage"] < 10000)
                        {
                            cars[car]["mileage"] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (var car in cars.OrderByDescending(x => x.Value["mileage"]).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value["mileage"]} kms, Fuel in the tank: {car.Value["fuel"]} lt.");
            }
        }
    }
}
