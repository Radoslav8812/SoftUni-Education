using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.InterFaces
{
    public interface IAnimal
    {
        public string Name { get; }
        public double  Weight { get; }
        public int FoodEaten { get; }

        string ProduceSound();
        void Eat(IFood food);
    }
}
