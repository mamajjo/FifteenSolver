using BoardModel;
using DataHandler;
using FifteenSolvers.Comparer;
using System.Collections.Generic;

namespace FifteenSolvers
{
    public abstract class BaseSolver
    {
        public MoveEnum[] MoveOrder { get; set; }
        protected Board CurrentBoard;
        public HashSet<Board> HashedBoardsSet { get; set; }
        public int CanNotSolve { get; set; }
        public IEqualityComparer<Board> BoardsEqualityComparer { get; set; }
        public Board SolvedBoard { get; set; }

        #region InfoFields

        public int BoardsVisited = 0;
        public int BoardsProcessed { get; set; }
        public int MaxDepth { get; set; }
        public InformationStringBuilder InformationToFileBuilder { get; set; }
        private readonly byte[,] gameOverBoard = { { 1 } };

        #endregion InfoFields

        protected BaseSolver()
        {
            InformationToFileBuilder = new InformationStringBuilder();
            BoardsProcessed = 1;
            BoardsEqualityComparer = new BoardsComparer();
            HashedBoardsSet = new HashSet<Board>(BoardsEqualityComparer);
        }

        public Board Solve()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BoardsVisited++;
            CurrentBoard = GetNextBoardInContainer();
            while (!CurrentBoard.IsSolved())
            {
                BoardsVisited++;
                InitializeChildrenBoards(CurrentBoard);
                HashedBoardsSet.Add(CurrentBoard);
                CurrentBoard = GetNextBoardInContainer();

                if (CurrentBoard.TreeDepth >= MaxDepth)
                {
                    MaxDepth = CurrentBoard.TreeDepth;
                }
            }

            BoardsVisited++;

            SolvedBoard = CurrentBoard;
            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;
            if(CanNotSolve != -1)
                InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited, BoardsProcessed,
                    MaxDepth, elapsedMs);

            return SolvedBoard;
        }

        public abstract void InitializeChildrenBoards(Board currentBoard);

        public abstract Board GetNextBoardInContainer();

        public abstract void InitializeContainers(Board initialBoard);
    }
}