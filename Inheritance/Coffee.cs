using System;
namespace Restaurant.Products.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name, 3.50m, 50)
        {
            this.CoffeeMilliliters = 50;
            this.CoffeePrice = 3.50m;
            this.Caffeine = caffeine;
        }
        public double CoffeeMilliliters { get; set; }
        public decimal CoffeePrice { get; set; }
        public double Caffeine { get; set; }
    }
}
