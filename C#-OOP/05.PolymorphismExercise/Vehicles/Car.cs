using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;           
        }


        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set
            {
                this.fuelConsumption = value + 0.9;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            set
            {
                this.tankCapacity = value;
            }
        }

        public void Driving(double km)
        {
            double neededFuel = km * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= neededFuel;
        }

        public void Refueling(double literes)
        {
            if (literes <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + literes > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {literes} fuel in the tank");
            }
           
            this.FuelQuantity += literes;
        }
    }
}
