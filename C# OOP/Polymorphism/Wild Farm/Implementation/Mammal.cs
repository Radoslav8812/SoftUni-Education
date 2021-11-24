using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementation
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        string Breed { get; set; }
        public string LivingRegion { get; set; }
    }
}
