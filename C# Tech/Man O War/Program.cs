using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            var PirateShipList = Console.ReadLine().Split('>').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
            var WarShipList = Console.ReadLine().Split('>').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
            int healthCapacity = int.Parse(Console.ReadLine());

            string input;
            bool IsBroken = false;

            while ((input = Console.ReadLine()) != "Retire")
            {
                var splitedInput = input.Split(" ").ToList();
                string command = splitedInput[0];

                if (command == "Fire")
                {
                    int index = int.Parse(splitedInput[1]);
                    int dmg = int.Parse(splitedInput[2]);

                    if (index >= 0 && index < WarShipList.Count)
                    {
                        WarShipList[index] -= dmg;

                        if (WarShipList[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            IsBroken = true;
                            break;
                        }
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(splitedInput[1]);
                    int endIndex = int.Parse(splitedInput[2]);
                    int dmg = int.Parse(splitedInput[3]);

                    if (startIndex >= 0 && startIndex < PirateShipList.Count && endIndex >= 0 && endIndex < PirateShipList.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            PirateShipList[i] -= dmg;

                            if (PirateShipList[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                IsBroken = true;
                                break;
                            }
                        }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(splitedInput[1]);
                    int health = int.Parse(splitedInput[2]);

                    if (index >= 0 && index < PirateShipList.Count)
                    {
                        PirateShipList[index] += health;

                        if (PirateShipList[index] > healthCapacity)
                        {
                            PirateShipList[index] = healthCapacity;
                        }
                    }
                }
                else if (command == "Status")
                {
                    double minCapacity = healthCapacity - (healthCapacity * 0.8);
                    int count = 0;

                    for (int i = 0; i < PirateShipList.Count; i++)
                    {
                        int currentSection = PirateShipList[i];

                        if (currentSection < minCapacity)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
            }
            if (IsBroken == false)
            {
                Console.WriteLine($"Pirate ship status: {PirateShipList.Sum()}");
                Console.WriteLine($"Warship status: {WarShipList.Sum()}");
            }
        }
    }
}
