using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astroRepo;
        private readonly IRepository<IPlanet> planetRepo;
        private readonly IMission missionRepo;
        private int exploredPlanet;

        public Controller()
        {
            astroRepo = new AstronautRepository();
            planetRepo = new PlanetRepository();
            missionRepo = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                astroRepo.Add(new Biologist(astronautName));
            }
            else if (type == "Geodesist")
            {
                astroRepo.Add(new Geodesist(astronautName));
            }
            else if (type == "Meteorologist")
            {
                astroRepo.Add(new Meteorologist(astronautName));
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepo.Add(planet);
            var result = $"Successfully added Planet: {planetName}!";
            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = astroRepo.Models.Where(x => x.Oxygen > 60).ToList();
            var dead = 0;

            if (!astronauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            else
            {
                var planet = planetRepo.FindByName(planetName);
                missionRepo.Explore(planet, astronauts);
                exploredPlanet++;

                foreach (var astronaut in astronauts)
                {
                    if (!astronaut.CanBreath)
                    {
                        dead++;
                    }
                }
            }

            return $"Planet: {planetName} was explored! Exploration finished with {dead} dead astronauts!";   
        }

        public string Report()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{exploredPlanet} planets were explored!");
            builder.AppendLine("Astronauts info:");

            foreach (var astro in astroRepo.Models)
            {
                builder.AppendLine($"Name: {astro.Name}");
                builder.AppendLine($"Oxygen: {astro.Oxygen}");
                string itemsInfo = astro.Bag.Items.Any() ? string.Join(", ", astro.Bag.Items) : "none";
                builder.AppendLine($"Bag items: {itemsInfo}");
            }

            return builder.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astroRepo.FindByName(astronautName);

            if (!astroRepo.Models.Contains(astronaut))
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astroRepo.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
