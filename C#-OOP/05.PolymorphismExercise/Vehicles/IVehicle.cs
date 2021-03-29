using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get;  }

        void Driving(double km);

        void Refueling(double literes);
           
    }
}
