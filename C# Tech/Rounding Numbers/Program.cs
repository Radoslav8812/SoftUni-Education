using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {            
            double[] array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (double n in array)
            {
                int rounded = (int)Math.Round(n, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} => {1}", n, rounded);
            }
        }
    }
}
