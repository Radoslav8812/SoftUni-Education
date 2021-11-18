using System;
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double default_Fuel_consumption = 3;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = default_Fuel_consumption;
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
