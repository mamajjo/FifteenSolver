using BoardModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When_MovingZeroInBoardInAllDirections_ShouldBeOk()
        {
            byte[,] testBytes = { { 1, 2, 3, 4 }, { 5, 6, 0, 8 }, { 9, 10, 12, 13 }, { 14, 15, 16, 17 } };
            Board testBoard = new Board(4, 4, testBytes);

            byte[,] expectedBytesUp = { { 1, 2, 0, 4 }, { 5, 6, 3, 8 }, { 9, 10, 12, 13 }, { 14, 15, 16, 17 } };
            Board actualBoardUp = testBoard.Shift(MoveEnum.U);

            byte[,] expectedBytesDown = { { 1, 2, 3, 4 }, { 5, 6, 12, 8 }, { 9, 10, 0, 13 }, { 14, 15, 16, 17 } };
            Board actualBoardDown = testBoard.Shift(MoveEnum.D);

            byte[,] expectedBytesLeft = { { 1, 2, 3, 4 }, { 5, 0, 6, 8 }, { 9, 10, 12, 13 }, { 14, 15, 16, 17 } };
            Board actualBoardLeft = testBoard.Shift(MoveEnum.L);

            byte[,] expectedBytesRight = { { 1, 2, 3, 4 }, { 5, 6, 8, 0 }, { 9, 10, 12, 13 }, { 14, 15, 16, 17 } };
            Board actualBoardRight = testBoard.Shift(MoveEnum.R);

            expectedBytesUp.Should().BeEquivalentTo(actualBoardUp.BoardInstance);
            expectedBytesDown.Should().BeEquivalentTo(actualBoardDown.BoardInstance);
            expectedBytesRight.Should().BeEquivalentTo(actualBoardRight.BoardInstance);
            expectedBytesLeft.Should().BeEquivalentTo(actualBoardLeft.BoardInstance);
        }

        [TestMethod]
        public void When_BoardIsSolved_ShouldBeOk()
        {
            byte[,] expectedBytes = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            Board actualSolvedBoard = new Board(4, 4, expectedBytes);

            actualSolvedBoard.IsSolved().Should().BeTrue();
        }
    }
}