using System;
using System.Collections.Generic;
using TicTacToe.Enums;
using TicTacToe.Implement;
using Index = TicTacToe.Implement.Index;

namespace TicTacToe.Interfaces
{
    public interface IBoard
    {
        bool IsFull();

        void PlaseSymbol(Index index, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbol(int row);

        Symbol GetColSymbol(int col);

        Symbol GetDiagonalTopRightBottomLeftSymbol();

        Symbol GetDiagonalTopLeftBottomRightSymbol();
    }
}
