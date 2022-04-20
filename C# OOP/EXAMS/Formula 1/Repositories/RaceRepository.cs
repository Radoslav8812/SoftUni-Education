using System;
using System.Linq;
using System.Collections.Generic;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
	public class RaceRepository : IRepository<IRace>
	{
        private List<IRace> models;

		public RaceRepository()
		{
            models = new List<IRace>();
		}

        public IReadOnlyCollection<IRace> Models => models;

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}

