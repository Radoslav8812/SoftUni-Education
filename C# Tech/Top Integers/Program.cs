using System;
using System.Linq;
using System.Collections.Generic;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int i = 0; i < numArray.Length - 1; i++)
            {
                int currentDigit = numArray[i];
                bool isTopInteger = true;

                for (int j = i + 1; j < numArray.Length; j++)
                {
                    int otherDigit = numArray[j];

                    if (currentDigit <= otherDigit)
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    Console.Write(currentDigit + " ");
                }
            }
            Console.WriteLine(numArray[numArray.Length - 1]);
        }
    }
}
