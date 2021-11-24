using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.InterFaces;

namespace WildFarm.Implementation
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            FoodEaten += food.FoodQuantity;
            Weight += food.FoodQuantity * 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
