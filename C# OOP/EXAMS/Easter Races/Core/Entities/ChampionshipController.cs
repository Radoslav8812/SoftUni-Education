using System;
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepo;
        private readonly IRepository<ICar> carRero;
        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            driverRepo = new DriverRepository();
            carRero = new CarRepository();
            raceRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = carRero.GetByName(carModel);
            var driver = driverRepo.GetByName(driverName);

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
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
            type += "Car";
            ICar car = null;

            if (type == nameof(MuscleCar))
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == nameof(SportsCar))
            {
                car = new SportsCar(model, horsePower);
            }

            carRero.Add(car);
            return $"{car} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            driverRepo.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            raceRepo.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepo.GetByName(raceName);
            var sb = new StringBuilder();

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var winnerList = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            raceRepo.Remove(race);

            sb.AppendLine($"Driver {winnerList[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {winnerList[1].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {winnerList[2].Name} wins {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
