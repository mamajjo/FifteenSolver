using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardModel;
using DataHandler;

namespace UnitTests.BoardTest
{
    [TestClass]
    public class ShiftingTests
    {
        private static MoveEnum[] moveEnums = { MoveEnum.D, MoveEnum.L, MoveEnum.R, MoveEnum.U };
        Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard.txt"), moveEnums, null);
        [TestMethod]
        public void ShiftDownShoudBeOk()
        {
            testingBoard.Shift(MoveEnum.D);
            Board shiftedBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard.txt"), moveEnums, null);
            Assert.AreEqual(testingBoard, shiftedBoard);
        }
    }
}
