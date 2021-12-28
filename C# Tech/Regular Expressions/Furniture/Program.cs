using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]*)<<([0-9]+(\.[0-9]+|))!([0-9]+)";
            string input = Console.ReadLine();
            var furnituresList = new List<string>();

            decimal totalSpentMoney = 0;

            while (input != "Purchase")
            {
                var match = Regex.Match(input, pattern);
                var isItMatch = Regex.IsMatch(input, pattern);
                if (isItMatch)
                {
                    string name = match.Groups[1].Value;
                    decimal price = decimal.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[4].Value);

                    furnituresList.Add(name);
                    totalSpentMoney += price * quantity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Bought furniture:");
            foreach (var item in furnituresList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalSpentMoney:f2}");
        }
    }
}
