using BoardModel;
using FifteenSolvers.Solvers;
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
            byte[,] expectedBytes = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 14, 0, 11 }, { 13, 15, 10, 12 } };
            MoveEnum[] testPriority = { MoveEnum.U, MoveEnum.D, MoveEnum.L, MoveEnum.R };
            Board expectedBoard = new Board(4, 4, expectedBytes);
            ManhattanSolver testSolver = new ManhattanSolver(testPriority);
            testSolver.InitializeContainers(expectedBoard);
            testSolver.Solve();
            testSolver.SolvedBoard.IsSolved().Should().BeTrue();
        }
    }
}