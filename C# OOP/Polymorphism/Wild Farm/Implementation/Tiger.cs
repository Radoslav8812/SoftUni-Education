using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.InterFaces;

namespace WildFarm.Implementation
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            LivingRegion = livingRegion;
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                FoodEaten += food.FoodQuantity;
                Weight += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public string LivingRegion { get; set; }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
