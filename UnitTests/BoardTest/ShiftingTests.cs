using BoardModel;
using DataHandler;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.BoardTest
{
    [TestClass]
    public class ShiftingTests
    {
        private static MoveEnum[] moveEnums = { MoveEnum.D, MoveEnum.L, MoveEnum.R, MoveEnum.U };
        private Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard1.txt"), new List<MoveEnum>());

        [TestMethod]
        public void ShiftDownShoudBeOk()
        {
            Board expectedBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\shiftedBoard.txt"), new List<MoveEnum>());
            Board shiftedBoard;
            shiftedBoard = testingBoard.Shift(MoveEnum.D);
            expectedBoard.BoardInstance.Should().BeEquivalentTo(shiftedBoard.BoardInstance);
            //  Assert.AreEqual(expectedBoard, shiftedBoard);
        }
    }
}