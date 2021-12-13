using System;
using System.Linq;
using System.Collections.Generic;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            int whiteRow = -1;
            int whiteCol = -1;

            int blackRow = -1;
            int blackCol = -1;

            //пълним матрицата
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }
            List<char> boardLetters = new List<char>();
            boardLetters.Add('a');
            boardLetters.Add('b');
            boardLetters.Add('c');
            boardLetters.Add('d');
            boardLetters.Add('e');
            boardLetters.Add('f');
            boardLetters.Add('g');
            boardLetters.Add('h');
            //координати (boardLetters[col])(8-row)
            
            //предвижваме пешките
            while (true)
            {
                //при победа
                if (whiteRow - 1 < 0)
                {
                    matrix[whiteRow, whiteCol] = '-';
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {boardLetters[whiteCol]}{8 - whiteRow}.");
                    break;
                }
                if (blackRow + 1 >= matrix.GetLength(0))
                {
                    matrix[blackRow, blackCol] = '-';
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {boardLetters[blackCol]}{8 - blackRow}.");
                    break;
                }

                // проверка по диагонал

                if (IsValid(matrix, whiteRow - 1, whiteCol - 1) && matrix[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {boardLetters[whiteCol - 1]}{8 - whiteRow + 1}.");
                    break;
                }
                else if (IsValid(matrix, whiteRow - 1, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {boardLetters[whiteCol + 1]}{8 - whiteRow + 1}.");
                    break;
                }


                //придвижване напред

                matrix[blackRow, blackCol] = '-';
                whiteRow--;
                matrix[whiteRow, whiteCol] = 'w';

                if (IsValid(matrix, blackRow + 1, blackCol - 1) &&
                    matrix[blackRow + 1, blackCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {boardLetters[blackCol - 1]}{8 - (blackRow + 1) }.");
                    break;
                }
                else if (IsValid(matrix, blackRow + 1, blackCol + 1) &&
                    matrix[blackRow + 1, blackCol + 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {boardLetters[blackCol + 1]}{8 - (blackRow + 1) }.");
                    break;
                }
                matrix[blackRow, blackCol] = '-';
                blackRow++;
                matrix[blackRow, blackCol] = 'b';

            }


        }

        private static bool IsValid(char[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
