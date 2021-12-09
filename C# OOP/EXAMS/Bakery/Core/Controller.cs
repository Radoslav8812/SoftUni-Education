using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {

        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            else if (type == "Water")
            {
                drinks.Add(new Water(name, portion, brand));
            }

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(x => !x.IsReserved).ToList();
            string result = "";

            foreach (var table in freeTables)
            {
                result += table.GetFreeTableInfo() + Environment.NewLine;
            }

            return result.TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var builder = new StringBuilder();

            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            builder.AppendLine($"Table: {tableNumber}");
            builder.AppendLine($"Bill: {bill:f2}");

            return builder.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                var drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

                if (food == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
