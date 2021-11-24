using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.InterFaces;

namespace WildFarm.Implementation
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                FoodEaten += food.FoodQuantity;
                Weight += food.FoodQuantity * 0.25;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
