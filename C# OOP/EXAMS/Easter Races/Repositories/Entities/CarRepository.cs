using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> cars;

        public CarRepository()
        {
            cars = new Dictionary<string, ICar>();
        }

        public void Add(ICar model)
        {
            if (cars.ContainsKey(model.Model))
            {
                throw new ArgumentException($"Car {model.Model} is already create.");
            }

            cars.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars.Values.ToList();
        }

        public ICar GetByName(string name)
        {
            ICar car = null;

            if (cars.ContainsKey(name))
            {
                car = cars[name];
            }

            return car;
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model.Model);
        }
    }
}
