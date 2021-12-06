using System;
using System.Linq;
using System.Collections.Generic;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
        {
            get
            {
                return astronauts;
            }
        }

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return astronauts.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return astronauts.Remove(model);
        }
    }
}
