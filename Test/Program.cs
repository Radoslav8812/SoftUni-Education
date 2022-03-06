using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();


            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                list.Add(num);
            }

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
