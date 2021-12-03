using System;
using TicTacToe.Enums;
using TicTacToe.Interfaces;

namespace TicTacToe.Implement
{
    public class TIcTacToeGame
    {
        public TIcTacToeGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }

        public IPlayer FirstPlayer { get; set; }

        public IPlayer SecondPlayer { get; set; }

        public void Play()
        {
            Board board = new Board();
            var player1 = FirstPlayer;
            var symbol = Symbol.X;

            while(!IsGameOver(board))
            {
                var move = player1.Play(board);
                board.PlaseSymbol(move, symbol);

                if (player1 == FirstPlayer)
                {
                    player1 = SecondPlayer;
                    symbol = Symbol.O;
                }
                else
                {
                    player1 = FirstPlayer;
                    symbol = Symbol.X;
                }
            }

            var winner = GetWinner(board);
        }

        private Symbol GetWinner(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                var winner = board.GetRowSymbol(i);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            for (int i = 0; i < board.Cols; i++)
            {
                var winner = board.GetColSymbol(i);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            var diagonal1 = board.GetDiagonalTopLeftBottomRightSymbol();
            if (diagonal1 != Symbol.None)
            {
                return diagonal1;
            }

            var diagonal2 = board.GetDiagonalTopRightBottomLeftSymbol();
            if (diagonal2 != Symbol.None)
            {
                return diagonal2;
            }

            return Symbol.None;
        }

        private bool IsGameOver(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                if (board.GetRowSymbol(i) != Symbol.None)
                {
                    return true;
                }
            }

            for (int i = 0; i < board.Cols; i++)
            {
                if (board.GetColSymbol(i) != Symbol.None)
                {
                    return true;
                }
            }

            if (board.GetDiagonalTopLeftBottomRightSymbol() != Symbol.None)
            {
                return true;
            }

            if (board.GetDiagonalTopRightBottomLeftSymbol() != Symbol.None)
            {
                return true;
            }

            if (board.IsFull())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
