using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Implementation
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double litters)
        {
            ValidateLiters(litters);
            ValidateQuantity(litters);
            litters *= 0.95;
            base.Refuel(litters);
        }
    }
}
