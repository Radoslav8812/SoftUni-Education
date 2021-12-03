using System;
using System.Collections.Generic;
using TicTacToe.Enums;
using TicTacToe.Interfaces;
using Index = TicTacToe.Implement.Index;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Symbol[,] board;

        public Board() : this(3, 3)
        {

        }

        public Board(int rows, int cols)
        {
            if (rows != cols)
            {
                throw new ArgumentException("Rows should be equal to Cols!");
            }

            Rows = rows;
            Cols = cols;
            board = new Symbol[rows, cols];
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public Symbol[,] BoardState { get; set; }

        public Symbol GetColSymbol(int col)
        {
            var symbol = board[0, col];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 0; row < Rows; row++)
            {
                if (board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetRowSymbol(int row)
        {
            var symbol = board[row, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int col = 1; col < Cols; col++)
            {
                if (board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTopLeftBottomRightSymbol()
        {
            var symbol = board[0, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int i = 1; i < Rows; i++)
            {
                if (board[i, i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTopRightBottomLeftSymbol()
        {
            var symbol = board[0, Rows - 1];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int i = 0; i < Rows; i++)
            {
                if (board[i, Rows - i - 1] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public IEnumerable<Index> GetEmptyPosition()
        {
            var positions = new List<Index>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (board[i, j] == Symbol.None)
                    {
                        positions.Add(new Index(i, j));
                    }
                }
            }

            return positions;
        }

        public bool IsFull()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (board[i, j] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaseSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Col < 0 || index.Row >= Rows || index.Col > Cols)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            board[index.Row, index.Col] = symbol;
        }
    }
}
