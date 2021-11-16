using System;
using System.Linq;
using System.Collections.Generic;
using Vehicles.Implementation;
using Vehicles.Interfaces;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carArgs = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carArgs[1]);
            var carFuelConsumption = double.Parse(carArgs[2]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            var truckArgs = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckArgs[1]);
            var truckFuelConsumption = double.Parse(truckArgs[2]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var splitedInput = Console.ReadLine().Split();

                if (splitedInput[0] == "Drive")
                {
                    var vehicle = splitedInput[1];
                    var value = double.Parse(splitedInput[2]);

                    if (vehicle == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (vehicle == "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (splitedInput[0] == "Refuel")
                {
                    var vehicle = splitedInput[1];
                    var value = double.Parse(splitedInput[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
