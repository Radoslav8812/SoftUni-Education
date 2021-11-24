using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Implementation
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double litters)
        {
            litters *= 0.95;
            base.Refuel(litters);
        }
    }
}
