using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class Summator
    {
        public int SumOfDigits(long n)
        {
            int sum = 0;
            n = Math.Abs(n);
            while (n != 0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            return sum;
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {

        }
    }
}
