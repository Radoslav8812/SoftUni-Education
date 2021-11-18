using System;
namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        private const double default_Fuel_consumption = 1.25;

        public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            FuelConsumption = default_Fuel_consumption;
        }
        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
