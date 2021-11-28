using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private int numberOfWins;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {name} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public ICar Car
        {
            get
            {
                return Car;
            }
            private set
            {
                Car = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return numberOfWins;
            }
            private set
            {
                numberOfWins = value;
            }
        }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Car cannot be null.");
            }
            else
            {
                Car = car;
            }
        }

        public void WinRace()
        {
            NumberOfWins += 1;
        }
    }
}
