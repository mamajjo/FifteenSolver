using System;
using BoardModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When_MovingZeroInBoardInAllDirections_ShouldBeOk()
        {
            byte[,] testBytes = {{1, 2, 3, 4}, {5, 6, 0, 8}, {9, 10, 12, 13}, {14, 15, 16, 17}};
            Board testBoard = new Board(4, 4, testBytes);

            byte[,] expectedBytesUp = { { 1, 2, 3, 4 }, { 5, 6, 0, 8 }, { 9, 10, 12, 13 }, { 14, 15, 16, 17 } };
            Board actualBoardUp = testBoard.Shift(MoveEnum.U);


        }
    }
}
