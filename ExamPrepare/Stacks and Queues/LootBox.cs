using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Loot_Box
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondInput = Console.ReadLine().Split().Select(int.Parse).ToList();

            var QueueNumbers = new Queue<int>(input);
            var StackNumbers = new Stack<int>(secondInput);
            var collectionList = new List<int>();

            int sum = 0;

            while (QueueNumbers.Any() && StackNumbers.Any())
            {
                int firstNum = QueueNumbers.Peek();
                int secondNum = StackNumbers.Pop();
                sum = firstNum + secondNum;

                if (sum % 2 == 0)
                {
                    collectionList.Add(sum);
                    QueueNumbers.Dequeue();
                }
                else
                {
                    int numberToAdd = secondNum;
                    QueueNumbers.Reverse();
                    QueueNumbers.Enqueue(numberToAdd);
                    QueueNumbers.Reverse();
                }
            }
            if (QueueNumbers.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (StackNumbers.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (collectionList.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectionList.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectionList.Sum()}");
            }
        }
    }
}
