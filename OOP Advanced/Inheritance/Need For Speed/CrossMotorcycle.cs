using System;
namespace NeedForSpeed
{
    public class CrossMotorcycle : Motorcycle
    {
        private const double default_Fuel_consumption = 1.25;

        public CrossMotorcycle(int horsePower, double fuel) : base (horsePower, fuel)
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
