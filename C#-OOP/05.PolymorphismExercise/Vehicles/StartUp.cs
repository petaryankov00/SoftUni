using System;
using System.ComponentModel;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));
            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]),double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Drive")
                {
                    try
                    {
                        double distance = double.Parse(input[2]);
                        if (input[1] == "Car")
                        {
                            car.Driving(distance);
                        }
                        else if(input[1] == "Truck")
                        {
                            truck.Driving(distance);
                        }
                        else
                        {                        
                            bus.Driving(distance);
                        }
                        Console.WriteLine($"{input[1]} travelled {distance} km");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (input[0] == "Refuel")
                {
                    try
                    {
                        double fuel = double.Parse(input[2]);
                        if (input[1] == "Car")
                        {
                            car.Refueling(fuel);
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refueling(fuel);
                        }
                        else
                        {
                            bus.Refueling(fuel);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    try
                    {
                        double distance = double.Parse(input[2]);
                        ((Bus)bus).DriveEmpty(distance);
                        Console.WriteLine($"{input[1]} travelled {distance} km");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
