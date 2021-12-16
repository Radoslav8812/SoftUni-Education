using System;

namespace armory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int playerRow = -1;
            int playerCol = -1;
            int mirror1Row = -1;
            int mirror1Col = -1;
            int mirror2Row = -1;
            int mirror2Col = -1;
            //int playerRow1 = -1;
            //int playerCol1 = -1;

            double count = 0;

            bool found = true;

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'A')
                    {
                        playerRow = row;
                        playerCol = col;
                        //playerRow1 = row;
                        //playerCol1 = col;

                    }
                    if (matrix[row, col] == 'M')
                    {
                        if (found)
                        {
                            mirror1Row = row;
                            mirror1Col = col;
                            found = false;
                           
                        }
                        else
                        {
                            mirror2Row = row;
                            mirror2Col = col;
                        }
                    }
                }
            }


            while (true)
            {


                var command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }


                if (matrix.GetLength(0) <= playerRow || playerRow < 0)
                {

                    break;
                }
                if (matrix.GetLength(1) <= playerCol || playerCol < 0)
                {
                    break;

                }

                if (matrix[playerRow, playerCol] != '-' && matrix[playerRow, playerCol] != 'M')
                {
                    char num = matrix[playerRow, playerCol];
                    var a  = Char.GetNumericValue(num);
                    count += a;



                    matrix[playerRow, playerCol] = 'A';
                    if (count >= 65)
                    {
                        break;
                    }
                }
                if (matrix[playerRow, playerCol] == 'M')
                {
                    if (playerRow == mirror1Row && playerCol == mirror1Col)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = mirror2Row;
                        playerCol = mirror2Col;
                        matrix[playerRow, playerCol] = 'A';
                    }
                    else if (playerRow == mirror2Row && playerCol == mirror2Col)
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = mirror1Row;
                        playerCol = mirror1Col;
                        matrix[playerRow, playerCol] = 'A';
                    }
                }


            }

            if (count >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
              
            } else
            {
                Console.WriteLine("I do not need more swords!");
            }
            Console.WriteLine($"The king paid {count} gold coins.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
