using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Implementation
{
    public class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }

        public bool CanDrive(double km)
        {
            if (FuelQuantity - (km * FuelConsumption) >= 0)
            {
                return true;
            }
            return false;
        }
        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                fuelQuantity -= km * FuelConsumption;
            }
            else
            {
                return;
            }

        }

        public virtual void Refuel(double litters)
        {
            fuelQuantity += litters;
        }
    }
}
