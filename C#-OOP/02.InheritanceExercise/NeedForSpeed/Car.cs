using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConspumtion = 3;

        public Car(int horsePower, double fuel)
            :base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConspumtion;

        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
