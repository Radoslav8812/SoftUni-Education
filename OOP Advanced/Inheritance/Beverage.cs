using System;
namespace Restaurant.Products
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.Milliliters = milliliters;
        }
        public virtual double Milliliters { get; set; }

    }
}
