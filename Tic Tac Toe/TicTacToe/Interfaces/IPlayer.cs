using System;
using Index = TicTacToe.Implement.Index;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        Index Play(Board board);
    }
}
