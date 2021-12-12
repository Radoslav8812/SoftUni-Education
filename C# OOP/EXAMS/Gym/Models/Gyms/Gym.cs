﻿using System;
using System.Linq;
using System.Collections.Generic;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            athletes = new List<IAthlete>();
            equipment = new List<IEquipment>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get
            {
                return this.equipment.Sum(x => x.Weight);
            }
        }

        public ICollection<IEquipment> Equipment
        {
            get
            {
                return equipment;
            }
        }

        public ICollection<IAthlete> Athletes
        {
            get
            {
                return athletes;
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count >= this.Capacity) // ?
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var item in athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{this.Name} is a {this.GetType().Name}");
            builder.AppendLine($"Athletes: {(this.Athletes.Any() ? string.Join(", ", this.Athletes.Select(x => x.FullName)) : "No athletes")}");
            builder.AppendLine($"Equipment total count: { this.Equipment.Count}");
            builder.AppendLine($"Equipment total weight: {Equipment.Sum(x => x.Weight)} grams");


            return builder.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }
    }
}
