using System;
using BoardModel;
using FifteenSolvers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void When_WholeDFSAlgorithmIsDone_ShouldBeOk()
        {
            byte[,] expectedBytes = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 0, 15 } };
            MoveEnum[] testPriority = {MoveEnum.L, MoveEnum.D, MoveEnum.R, MoveEnum.U};
            Board expectedBoard = new Board(4, 4, expectedBytes);
            DFSSolver testSolver = new DFSSolver(expectedBoard, testPriority);
            testSolver.Solve();
            testSolver.SolvedBoard.IsSolved().Should().BeTrue();
        }
    }
}
