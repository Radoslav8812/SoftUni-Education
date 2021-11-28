using System;
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {

        private readonly IDictionary<string, IRace> races;

        public RaceRepository()
        {
            races = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            if (races.ContainsKey(model.Name))
            {
                throw new ArgumentException($"Race {model.Name} is already create.");
            }

            races.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            IRace race = null;

            if (races.ContainsKey(name))
            {
                race = races[name];
            }
            return race;
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model.Name);
        }
    }
}
