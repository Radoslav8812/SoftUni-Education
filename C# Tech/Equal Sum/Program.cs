using System;
using System.Linq;
using System.Collections.Generic;

namespace Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = numbersArray.Sum();

            for (int i = 0; i < numbersArray.Length; i++)
            {
                rightSum -= numbersArray[i];

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbersArray[i];
            }
            Console.WriteLine("no");
        }
    }
}
