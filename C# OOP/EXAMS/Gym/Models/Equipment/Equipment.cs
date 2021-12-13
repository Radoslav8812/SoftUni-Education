using System;
using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {

        protected Equipment( double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; }

        public decimal Price { get; }
    }
}
