using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public int Count => data.Count;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            Car GetLatestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return GetLatestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var currentCar = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return currentCar;
        }

        public int GetterCount()
        {
            return data.Count;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
