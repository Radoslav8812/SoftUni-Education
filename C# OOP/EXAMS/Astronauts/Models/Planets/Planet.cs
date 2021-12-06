using System;
using System.Collections.Generic;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            Name = name;
            Items = new List<string>();
        }

        public ICollection<string> Items { get; }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Invalid name!");
                }
                name = value;
            }
        }
    }
}
