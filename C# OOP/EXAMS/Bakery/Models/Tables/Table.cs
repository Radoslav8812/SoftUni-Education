using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return PricePerPerson * NumberOfPeople;
            }
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();         
            NumberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var food in FoodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in DrinkOrders)
            {
                bill += drink.Price;
            }

            bill += Price;
            return bill;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
