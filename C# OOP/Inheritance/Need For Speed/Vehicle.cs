using System;
namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double default_Fuel_consumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            FuelConsumption = default_Fuel_consumption;
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual void Drive (double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
