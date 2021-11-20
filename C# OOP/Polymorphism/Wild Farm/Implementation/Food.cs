using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.InterFaces;

namespace WildFarm.Implementation
{
    public abstract class Food : IFood
    {
        protected Food(int foodQuantity)
        {
            FoodQuantity = foodQuantity;
        }
        public int FoodQuantity { get; set; }
    }
}
