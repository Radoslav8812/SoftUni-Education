using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquidsQue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var ingredientStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquidsQue.Count > 0 && ingredientStack.Count > 0)
            {
                var liquid = liquidsQue.Peek();
                var ingredient = ingredientStack.Peek();
                var sum = liquid + ingredient;

                if (sum == 25)
                {
                    bread++;
                    liquidsQue.Dequeue();
                    ingredientStack.Pop();
                }
                else if (sum == 50)
                {
                    cake++;
                    liquidsQue.Dequeue();
                    ingredientStack.Pop();
                }
                else if (sum == 75)
                {
                    pastry++;
                    liquidsQue.Dequeue();
                    ingredientStack.Pop();
                }
                else if (sum == 100)
                {
                    fruitPie++;
                    liquidsQue.Dequeue();
                    ingredientStack.Pop();
                }
                else
                {
                    liquidsQue.Dequeue();
                    var element = ingredientStack.Pop() + 3;
                    ingredientStack.Push(element);
                }
            }

            if (bread > 0 && cake > 0 && pastry > 0 && fruitPie > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");

                if (liquidsQue.Count == 0)
                {
                    Console.WriteLine("Liquids left: none");
                }
                else
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquidsQue)}");
                }

                if (ingredientStack.Count == 0)
                {
                    Console.WriteLine("Ingredients left: none");
                }
                else
                {
                    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientStack)}");
                }
                Console.WriteLine($"Bread: {bread}");
                Console.WriteLine($"Cake: {cake}");
                Console.WriteLine($"Fruit Pie: {fruitPie}");
                Console.WriteLine($"Pastry: {pastry}");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

                if (liquidsQue.Count == 0)
                {
                    Console.WriteLine("Liquids left: none");
                }
                else
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquidsQue)}");
                }

                if (ingredientStack.Count == 0)
                {
                    Console.WriteLine("Ingredients left: none");
                }
                else
                {
                    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientStack)}");
                }
                Console.WriteLine($"Bread: {bread}");
                Console.WriteLine($"Cake: {cake}");
                Console.WriteLine($"Fruit Pie: {fruitPie}");
                Console.WriteLine($"Pastry: {pastry}");
            }
        }
    }
}
