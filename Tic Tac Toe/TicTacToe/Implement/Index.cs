using System;
namespace TicTacToe.Implement
{
    public class Index
    {
        public Index(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return $"{Row},{Col}";
        }
    }
}
