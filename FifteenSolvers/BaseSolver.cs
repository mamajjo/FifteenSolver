using BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler;
using FifteenSolvers.Comparer;

namespace FifteenSolvers
{
    public abstract class BaseSolver
    {
        public MoveEnum[] MoveOrder { get; set; }
        protected Board InitBoard;
        public HashSet<Board> HashedBoardsSet { get; set; }
        public IEqualityComparer<Board> BoardsEqualityComparer { get; set; }
        public Board SolvedBoard { get; set; }

        #region InfoFields

        public List<Board> BoardsVisited = new List<Board>();
        public int BoardsProcessed { get; set; }
        public int MaxDepth { get; set; }
        public InformationStringBuilder InformationToFileBuilder { get; set; }

        #endregion

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

            bool isSolved = false;
            double elapsedMs;
            //IsContainerEmpty
            while (!isSolved)
            {
                Board currentBoard = GetNextBoardInContainer();
                if (currentBoard.IsSolved())
                {
                    isSolved = true;
                    SolvedBoard = currentBoard;
                    elapsedMs = watch.Elapsed.TotalMilliseconds;
                    InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited.Count,
                        BoardsProcessed, MaxDepth, elapsedMs);
                    return SolvedBoard;
                }
                else
                {
                    InitializeChildrenBoards(currentBoard);
                    HashedBoardsSet.Add(currentBoard);
                }
            }

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited.Count, BoardsProcessed,
                MaxDepth, elapsedMs);
            byte[,] gameOverBoard = {{1}};
            return new Board(1, 1, gameOverBoard);
        }

        public abstract void InitializeChildrenBoards(Board currentBoard);
        public abstract Board GetNextBoardInContainer();
        public abstract void InitializeContainers(Board initialBoard);
        public abstract bool IsContainerEmpty();



    }
}
