using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            var matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }
            
            while (true)
            {
                string commArgs = Console.ReadLine();

                if (commArgs == "Bloom Bloom Plow")
                {
                    break;
                }

                var furionRow = int.Parse(commArgs[0].ToString());
                var furionCol = int.Parse(commArgs[2].ToString());

                if (furionRow < 0 || furionRow > matrix.GetLength(0) || furionCol < 0 && furionCol > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[furionRow, i]++;
                }
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[i, furionCol]++;
                }
                matrix[furionRow, furionCol]--;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
