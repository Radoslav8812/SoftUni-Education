using System;
using System.Linq;
using System.Collections.Generic;
using Easter.Core.Contracts;
using Easter.Repositories.Contracts;
using Easter.Repositories;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnyRepository;
        private readonly EggRepository eggRepository;
        private readonly Workshop workshop;

        public Controller()
        {
            bunnyRepository = new BunnyRepository();
            eggRepository = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
                bunnyRepository.Add(bunny);
                return $"Successfully added {bunnyType} named {bunnyName}.";
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
                bunnyRepository.Add(bunny);
                return $"Successfully added {bunnyType} named {bunnyName}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = bunnyRepository.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            else
            {
                bunny.AddDye(dye);
                return $"Successfully added dye with power {power} to bunny {bunnyName}!";
            }
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggRepository.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggRepository.FindByName(eggName);
            var bunnyList = bunnyRepository.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (bunnyList.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            else
            {
                foreach (var bunny in bunnyList)
                {
                    workshop.Color(egg, bunny);

                    if (bunny.Energy == 0)
                    {
                        bunnyRepository.Remove(bunny);
                    }
                }
            }

            if (egg.IsDone())
            {
                return $"Egg {egg.Name} is done.";
            }
            else
            {
                return $"Egg {egg.Name} is not done.";
            }
            
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var coloredEggs = eggRepository.Models.Count(x => x.IsDone());

            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
