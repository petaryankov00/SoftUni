using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConspumtion = 10;

        public SportCar(int horsePower,double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConspumtion;

        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
