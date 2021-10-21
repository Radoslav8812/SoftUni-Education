using System;
using System.Collections.Generic;
using System.Text;
 
namespace TheRace
{
    public class Racer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Car Car { get; set; }
        public Racer(string name, int age, string country, Car Car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = Car;
        }
        public override string ToString()
        {
            return $"Racer: { this.Name}, { this.Age} ({ this.Country})";
        }
    }
}
#####################################################################################################################################
 
namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            bool isRacer = false;
            foreach (Racer racer in data)
            {
                if (racer.Name == name)
                {
                    isRacer = true;
                }
            }
            if (isRacer)
            {
                data.Remove(data.FirstOrDefault(racer => racer.Name == name));
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
            Racer racer = data.Where(x => x.Name == name).FirstOrDefault();
            return racer;
        }
        public Racer GetFastestRacer()
        {
            var racer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return racer;
        }
        public string Report()
        {
 
            if (data.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
 
                sb.AppendLine($"Racers participating at {Name}:");
 
                foreach (var racer in data)
                {
                    sb.AppendLine(racer.ToString());
                }
 
                return sb.ToString().TrimEnd();
            }
 
            return null;
        }
    }
}

#####################################################################################################################################

namespace TheRace
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
}

#####################################################################################################################################

namespace TheRace
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository
            Race race = new Race("Indianapolis 500", 10);

            //Initialzie cars
            Car car1 = new Car("ferrari", 150);
            Car car2 = new Car("lambo", 170);

            //Initialize racer1
            Racer racer1 = new Racer("Stephen", 40, "Bulgaria", car1);

            //Print Racer
            Console.WriteLine(racer1); //Racer: Stephen, 40 (Bulgaria)

            //Add Racer
            race.Add(racer1);
            //Remove Racer
            race.Remove("Vin Benzin"); //false

            Racer racer2 = new Racer("Mark", 34, "UK", car2);

            //Add Racer
            race.Add(racer2);

            Racer oldestRacer = race.GetOldestRacer(); // Racer with name Stephen
            Racer racerStephen = race.GetRacer("Stephen"); // Racer with name Stephen
            Racer fastestRacer = race.GetFastestRacer(); // Racer with name Mark

            Console.WriteLine(oldestRacer); //Racer: Stephen, 40 (Bulgaria)
            Console.WriteLine(racerStephen); //Racer: Stephen, 40 (Bulgaria)
            Console.WriteLine(fastestRacer); // Racer: Mark, 34 (UK)
            Console.WriteLine(race.Count); //2

            Console.WriteLine(race.Report());
            //Racers working at Indianapolis 500:
            //Racer: Stephen, 40 (Bulgaria)
            //Racer: Mark, 34 (UK)

        }
    }
}
