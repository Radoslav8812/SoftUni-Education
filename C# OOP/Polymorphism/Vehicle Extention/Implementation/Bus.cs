using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Implementation
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => this.IsEmpty ? base.FuelConsumption : base.FuelConsumption + 1.4;
        public bool CanDrive(double km)
        {
            throw new NotImplementedException();
        }

        public void Drive(double km)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double litters)
        {
            throw new NotImplementedException();
        }
    }
}
