using System;
using System.IO;
using System.Linq;

namespace StreamAndFIles
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"Countries.txt");
            using StreamWriter sw = new StreamWriter(@"CountriesWithLineNumbers.txt");

            int rowNumber = 1;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                sw.WriteLine($"{rowNumber}. {line}");
                rowNumber++;
            }
        }
    }
}
