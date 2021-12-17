using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;

            drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count
        {
            get
            {
                return drones.Count;
            }
        }

        public string AddDrone(Drone drone)
        {

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (drone.Brand == null || drone.Brand == string.Empty || drone.Name == null || drone.Name == string.Empty)
            { 
                    return "Invalid drone.";
            }
            else
            {
                if (drones.Count < Capacity)
                {
                    drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else
                {
                    return "Airfield is full.";
                }
            }
        }

        public bool RemoveDrone(string name)
        {
            var drone = drones.FirstOrDefault(x => x.Name == name);

            if (drone == null)
            {
                return false;
            }
            else
            {
                drones.Remove(drone);
                return true;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            var drone = drones.Where(x => x.Brand == brand).ToList();

            if (drone.Count > 0)
            {

                drones.RemoveAll(x => x.Brand == brand);
                return drone.Count;

            } else
            {
                return 0;
            }

        }

        public Drone FlyDrone(string name)
        {
            var drone = drones.FirstOrDefault(x => x.Name == name);
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var droness = drones.Where(x => x.Range >= range).ToList();
            return droness;
            
        }

        public string Report()
        {
            var currentDrones = drones.Where(x => x.Available).ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in currentDrones)
            {
                sb.AppendLine(drone.ToString().TrimEnd());
            }

            return sb.ToString();
        }
    }
}
