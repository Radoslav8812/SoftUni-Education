using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Implementation
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            BirthDate = birthdate;
            Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
