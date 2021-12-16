using System;
using System.Linq;
using System.Collections.Generic;

namespace BlackSmith
{
    class Program
    {
        static void Main(string[] args)
        {
            var que = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var Gladius = 70;
            var Shamshir = 80;
            var Katana = 90;
            var Sabre = 110;
            var Broadsword = 150;

            var GladiusCount = 0;
            var ShamshirCount = 0;
            var KatanaCount = 0;
            var SabreCount = 0;
            var BroadswordCount = 0;


            while (que.Count > 0 && stack.Count > 0)
            {
                var currSteel = que.Peek();
                var currCarbon = stack.Peek();
                var currSum = currSteel + currCarbon;

                if (currSum == Gladius)
                {
                    GladiusCount++;
                    que.Dequeue();
                    stack.Pop();
                }
                else if (currSum == Shamshir)
                {
                    ShamshirCount++;
                    que.Dequeue();
                    stack.Pop();
                }
                else if (currSum == Katana)
                {
                    KatanaCount++;
                    que.Dequeue();
                    stack.Pop();
                }
                else if (currSum == Sabre)
                {
                    SabreCount++;
                    que.Dequeue();
                    stack.Pop();
                }
                else if (currSum == Broadsword)
                {
                    BroadswordCount++;
                    que.Dequeue();
                    stack.Pop();
                }
                else
                {
                    que.Dequeue();
                    currCarbon += 5;
                    stack.Pop();
                    stack.Push(currCarbon);
                }
            }

            var totalNumberOfSwords = GladiusCount + SabreCount + ShamshirCount + KatanaCount + BroadswordCount;

            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            } else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (que.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", que)}");
            } else
            {
                Console.WriteLine("Steel left: none");
            }
            if (stack.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            if (BroadswordCount > 0)
            {
                Console.WriteLine($"Broadsword: {BroadswordCount}");
            }
            if (SabreCount > 0)
            {
                Console.WriteLine($"Sabre: {SabreCount}");
            }
            if (KatanaCount > 0)
            {
                Console.WriteLine($"Katana: {KatanaCount}");
            }
            if (ShamshirCount > 0)
            {
                Console.WriteLine($"Shamshir: {ShamshirCount}");
            }
            if (GladiusCount > 0)
            {
                Console.WriteLine($"Gladius: {GladiusCount}");
            }
        }
    }
}
