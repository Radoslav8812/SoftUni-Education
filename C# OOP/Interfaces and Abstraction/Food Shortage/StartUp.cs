using FoodShortage.Implementation;
using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var personHash = new HashSet<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var splitedInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitedInput.Length == 4)
                {
                    var name = splitedInput[0];
                    var age = int.Parse(splitedInput[1]);
                    var id = splitedInput[2];
                    var birthdate = splitedInput[3];

                    personHash.Add(new Citizen(name, age, id, birthdate));
                }
                else if (splitedInput.Length == 3)
                {
                    var name = splitedInput[0];
                    var age = int.Parse(splitedInput[1]);
                    var group = splitedInput[2];

                    personHash.Add(new Rebel(name, age, group));
                }
            }

            var inputName = Console.ReadLine();
            var collectedFood = 0;

            while (inputName != "End")
            {
                foreach (var person in personHash.Where(x => x.Name == inputName))
                {
                    person.BuyFood();
                }

                inputName = Console.ReadLine();
            }

            foreach (var rebel in personHash)
            {
                collectedFood += rebel.Food;
            }
            Console.WriteLine(collectedFood);
        }
    }
}
