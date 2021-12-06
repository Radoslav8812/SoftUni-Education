using System;
using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            if (astronauts.All(x => x.Oxygen > 0))
            {

            }

            foreach (var astrounaut in astronauts)
            {
                while (astrounaut.CanBreath && planet.Items.Any())
                {
                    var item = planet.Items.FirstOrDefault();
                    astrounaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astrounaut.Breath();
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
