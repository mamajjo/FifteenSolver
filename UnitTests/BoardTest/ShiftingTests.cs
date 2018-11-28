using System;
using System.Collections.Generic;
using BoardModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataHandler;
using FluentAssertions;

namespace UnitTests.BoardTest
{
    [TestClass]
    public class ShiftingTests
    {
        private static MoveEnum[] moveEnums = {MoveEnum.D, MoveEnum.L, MoveEnum.R, MoveEnum.U};
        Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard1.txt"), new List<MoveEnum>());
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
