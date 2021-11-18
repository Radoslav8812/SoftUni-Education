using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Implementation
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
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
                if (value > tankCapacity)
                {
                    value = 0;
                }
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

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            private set
            {
                tankCapacity = value;
            }
        }

        public bool IsEmpty { get; set; }
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
            ValidateLiters(litters);
            ValidateQuantity(litters);
            fuelQuantity += litters;
        }

        protected void ValidateQuantity(double litters)
        {
            if (FuelQuantity + litters > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litters} fuel in the tank");
            }
        }

        protected static void ValidateLiters(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
