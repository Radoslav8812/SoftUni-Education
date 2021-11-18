using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Implementation
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
