using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepo;
        private readonly IRepository<ICar> carRepo;
        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            driverRepo = new DriverRepository();
            carRepo = new CarRepository();
            raceRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = driverRepo.GetByName(driverName);
            var car = carRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepo.GetByName(raceName);
            var driver = driverRepo.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var existCar = carRepo.GetByName(model);

            if (existCar != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepo.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driverExist = driverRepo.GetByName(driverName);

            if (driverExist != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            else
            {
                var driver = new Driver(driverName);
                driverRepo.Add(driver);
                return $"Driver {driverName} is created.";
            }
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepo.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            else
            {
                var race = new Race(name, laps);
                raceRepo.Add(race);
                return $"Race {name} is created.";
            }
        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var topDrivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            var first = topDrivers[0];
            var second = topDrivers[1];
            var third = topDrivers[2];

            var builder = new StringBuilder();

            builder.AppendLine($"Driver {first.Name} wins {race.Name} race.");
            builder.AppendLine($"Driver {second.Name} is second in {race.Name} race.");
            builder.AppendLine($"Driver {third.Name} is third in {race.Name} race.");

            return builder.ToString().TrimEnd();
        }
    }
}
