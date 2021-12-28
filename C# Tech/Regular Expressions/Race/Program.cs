using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double>();
            var namesList = Console.ReadLine().Split(", ").ToList();

            foreach (var item in namesList)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 0;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                string name = string.Empty;
                double distance = 0;

                if (input == "end of race")
                {
                    break;
                }
                else
                {
                    Regex regex = new Regex(@"[A-Za-z]");
                    MatchCollection matches = regex.Matches(input);

                    foreach (Match match in matches)
                    {
                        name += match.Value;
                    }

                    if (dict.ContainsKey(name))
                    {
                        MatchCollection matchesDistance = Regex.Matches(input, @"[0-9]");

                        foreach (Match item in matchesDistance)
                        {
                            distance += double.Parse(item.Value);
                        }
                        dict[name] += distance;
                    }
                }
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            int count = 1;
            foreach (var items in dict)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {items.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {items.Key}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {items.Key}");
                }
                else
                {
                    break;
                }
                count++;
            }
        }
    }
}
