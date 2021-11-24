using System;
using System.Linq;

namespace Reverse_Array_Of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayText = Console.ReadLine().Split().ToArray();
            arrayText = arrayText.Reverse().ToArray();

            for (int i = 0; i < arrayText.Length; i++)
            {
                Console.Write(arrayText[i] + " ");
            }
        }
    }
}
