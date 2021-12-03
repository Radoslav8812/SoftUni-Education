using NUnit.Framework;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacToeTests
{
    [TestFixture]
    public class BoardTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FullMethodCorrectly()
        {
            var board = new Board(3, 3);

            Assert.IsFalse(board.IsFull());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaseSymbol(new TicTacToe.Implement.Index(i, j), Symbol.X);
                }
            }

            Assert.IsTrue(board.IsFull());            
        }

        [Test]
        public void GetRowSymbolWorkCorrectly()
        {
            var board = new Board(3, 3);

            for (int i = 0; i < board.Cols; i++)
            {
                Assert.AreEqual(Symbol.None, board.GetRowSymbol(2));

                board.PlaseSymbol(new TicTacToe.Implement.Index(2, i), Symbol.O);
            }

            Assert.AreEqual(Symbol.O, board.GetRowSymbol(2));
        }
    }
}
