using System;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        public Bread(string name, decimal price) : base(name, 200, price)
        {
        }
    }
}
