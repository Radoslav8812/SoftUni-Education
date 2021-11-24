using System;
using System.Linq;
using System.Collections.Generic;

namespace EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var gifts = Console.ReadLine().Split(" ").ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No Money")
            {
                if (input == "No Money")
                {
                    break;
                }

                string[] splitedInput = input.Split(" ").ToArray();
                string firstInput = splitedInput[0];

                if (splitedInput[0] == "OutOfStock")
                {
                    if (splitedInput.Count() == 2)
                    {
                        for (int i = 0; i < gifts.Count; i++)
                        {
                            if (gifts[i].Contains(splitedInput[1]))
                            {
                                int index = gifts.IndexOf(splitedInput[1]);
                                gifts.Remove(splitedInput[1]);
                                gifts.Insert(index, "None");
                            }
                        }
                    }
                }
                else if (splitedInput[0] == "Required")
                {
                    if (splitedInput.Count() == 3)
                    {
                        string gift = splitedInput[1];
                        int index = int.Parse(splitedInput[2]);
                        if (index < gifts.Count - 1)
                        {
                            gifts.RemoveAt(index);
                            gifts.Insert(index, gift);
                        }
                    }
                }
                else if (splitedInput[0] == "JustInCase")
                {
                    if (splitedInput.Count() == 2)
                    {
                        int indexLastGift = gifts.Count - 1;
                        gifts.RemoveAt(indexLastGift);
                        gifts.Add(splitedInput[1]);
                    }
                }
            }
            if (gifts.Contains("None"))
            {
                gifts.RemoveAll(gift => gift == "None");
            }
            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}