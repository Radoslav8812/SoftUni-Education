using System;
using System.IO;
using System.Linq;

namespace StreamAndFIles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Environment.CurrentDirectory);
            //var sw = new StreamWriter(@"output.txt");
            //sw.WriteLine("just test");
            //sw.Close();

            using StreamReader sr = new StreamReader(@"Countries.txt");
            using StreamWriter sw = new StreamWriter(@"OddCountries.txt");


            int rowNumber = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (rowNumber % 2 != 0)
                {
                    sw.WriteLine(line);
                }

                rowNumber++;
            }
        }
    }
}
