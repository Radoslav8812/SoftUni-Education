using System;
using System.Linq;
using System.Collections.Generic;
using WildFarm.Implementation;
using WildFarm.InterFaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animalList = new List<IAnimal>();
            var input = Console.ReadLine();

            while (input != "End")
            {
                var splitedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var animalType = splitedInput[0];

                var foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var foodType = foodInfo[0];
                var quantity = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal animal = null;

                    if (animalType == "Cat" || animalType == "Tiger")
                    {                       
                        var name = splitedInput[1];
                        var weight = double.Parse(splitedInput[2]);
                        var livingRegion = splitedInput[3];
                        var breed = splitedInput[4];

                        if (animalType == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);

                        }
                    }
                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        var name = splitedInput[1];
                        var weight = double.Parse(splitedInput[2]);
                        var wingSize = int.Parse(splitedInput[3]);

                        if (animalType == "Owl")
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                        else
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                    }
                    else if (animalType == "Dog" || animalType == "Mouse")
                    {
                        var name = splitedInput[1];
                        var weight = double.Parse(splitedInput[2]);
                        var livingRegion = splitedInput[3];

                        if (animalType == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                        else
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());
                    animalList.Add(animal);

                    IFood food = null;
                    if (foodType == "Fruit")
                    {
                        food = new Fruit(quantity);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(quantity);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(quantity);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(quantity);
                    }
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
