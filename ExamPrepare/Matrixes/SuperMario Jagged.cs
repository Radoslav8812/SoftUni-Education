using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            if (rows == 0)
            {
                return;
            }

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                char[] arr = line.ToArray();
                matrix[i] = arr;
            }

            int rowMario = 0;
            int colMario = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        rowMario = i;
                        colMario = j;
                        break;
                    }
                }
            }

            while (true)
            {
                string[] CommArgs = Console.ReadLine().Split();
                string direction = CommArgs[0];
                int rowSpawn = int.Parse(CommArgs[1]);
                int colSpawn = int.Parse(CommArgs[2]);

                matrix[rowSpawn][colSpawn] = 'B';

                health -= 1;
                if (direction == "W")
                {
                    if (IsValidIndexes(rowMario - 1, colMario, matrix))
                    {
                        if (matrix[rowMario - 1][colMario] == 'B')
                        {
                            health -= 2;
                            if (health <= 0)
                            {
                                Console.WriteLine($"Mario died at {rowMario - 1};{colMario}.");
                                matrix[rowMario - 1][colMario] = 'X';
                                matrix[rowMario][colMario] = '-';
                                break;
                            }
                            else
                            {
                                matrix[rowMario - 1][colMario] = 'M';
                                matrix[rowMario][colMario] = '-';
                                rowMario--;
                            }
                        }
                        else if (matrix[rowMario - 1][colMario] == 'P')
                        {
                            matrix[rowMario - 1][colMario] = '-';
                            matrix[rowMario][colMario] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                            break;
                        }
                        else
                        {
                            matrix[rowMario - 1][colMario] = 'M';
                            matrix[rowMario][colMario] = '-';
                            rowMario--;
                        }

                    }
                }
                else if (direction == "S")
                {
                    if (IsValidIndexes(rowMario + 1, colMario, matrix))
                    {
                        if (matrix[rowMario + 1][colMario] == 'B')
                        {
                            health -= 2;
                            if (health <= 0)
                            {
                                Console.WriteLine($"Mario died at {rowMario + 1};{colMario}.");
                                matrix[rowMario + 1][colMario] = 'X';
                                matrix[rowMario][colMario] = '-';
                                break;
                            }
                            else
                            {
                                matrix[rowMario + 1][colMario] = 'M';
                                matrix[rowMario][colMario] = '-';
                                rowMario++;
                            }
                        }
                        else if (matrix[rowMario + 1][colMario] == 'P')
                        {
                            matrix[rowMario + 1][colMario] = '-';
                            matrix[rowMario][colMario] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                            break;
                        }
                        else
                        {
                            matrix[rowMario + 1][colMario] = 'M';
                            matrix[rowMario][colMario] = '-';
                            rowMario++;
                        }

                    }


                }
                else if (direction == "A")
                {
                    if (IsValidIndexes(rowMario, colMario - 1, matrix))
                    {
                        if (matrix[rowMario][colMario - 1] == 'B')
                        {
                            health -= 2;
                            if (health <= 0)
                            {
                                Console.WriteLine($"Mario died at {rowMario};{colMario - 1}.");
                                matrix[rowMario][colMario - 1] = 'X';
                                matrix[rowMario][colMario] = '-';
                                break;
                            }
                            else
                            {
                                matrix[rowMario][colMario - 1] = 'M';
                                matrix[rowMario][colMario] = '-';
                                colMario--;
                            }
                        }
                        else if (matrix[rowMario][colMario - 1] == 'P')
                        {
                            matrix[rowMario][colMario - 1] = '-';
                            matrix[rowMario][colMario] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                            break;
                        }
                        else
                        {
                            matrix[rowMario][colMario - 1] = 'M';
                            matrix[rowMario][colMario] = '-';
                            colMario--;
                        }

                    }
                }
                else if (direction == "D")
                {
                    if (IsValidIndexes(rowMario, colMario + 1, matrix))
                    {
                        if (matrix[rowMario][colMario + 1] == 'B')
                        {
                            health -= 2;
                            if (health <= 0)
                            {
                                Console.WriteLine($"Mario died at {rowMario};{colMario + 1}.");
                                matrix[rowMario][colMario + 1] = 'X';
                                matrix[rowMario][colMario] = '-';
                                break;
                            }
                            else
                            {
                                matrix[rowMario][colMario + 1] = 'M';
                                matrix[rowMario][colMario] = '-';
                                colMario++;
                            }
                        }
                        else if (matrix[rowMario][colMario + 1] == 'P')
                        {
                            matrix[rowMario][colMario + 1] = '-';
                            matrix[rowMario][colMario] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                            break;
                        }
                        else
                        {
                            matrix[rowMario][colMario + 1] = 'M';
                            matrix[rowMario][colMario] = '-';
                            colMario++;
                        }
                    }
                }

                if (health == 0)
                {
                    Console.WriteLine($"Mario died at {rowMario};{colMario}.");
                    matrix[rowMario][colMario] = 'X';
                    break;
                }
            }

            PrintMatrix(matrix);
        }
        public static bool IsValidIndexes(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }

        }

    }
}
