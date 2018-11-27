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
        public HashSet<Board> VisitedBoards { get; set; }
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
            VisitedBoards = new HashSet<Board>(BoardsEqualityComparer);
        }

        public Board Solve()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            bool isSolved = false;
            long elapsedMs;
            //IsContainerEmpty
            while (!isSolved)
            {
                Board currentBoard = GetNextBoardInContainer();
                if (currentBoard.IsSolved())
                {
                    isSolved = true;
                    SolvedBoard = currentBoard;
                    elapsedMs = watch.ElapsedMilliseconds;
                    InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited.Count, BoardsProcessed, MaxDepth, elapsedMs);
                    return SolvedBoard;
                }
                else
                {
                    InitializeChildrenBoards(currentBoard);
                    VisitedBoards.Add(currentBoard);
                }
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited.Count, BoardsProcessed, MaxDepth, elapsedMs);
            byte[,] gameOverBoard = {{ 1 } };
            return new Board(1,1, gameOverBoard);
        }
        public abstract void InitializeChildrenBoards(Board currentBoard);
        public abstract Board GetNextBoardInContainer();
        public abstract void InitializeContainers(Board initialBoard);
        public abstract bool IsContainerEmpty();



    }
}
//namespace FifteenSolvers
//{
//    public class DFSSolver : BaseSolver
//    {
//        public Stack<Board> BoardsStack { get; set; }
//        public HashSet<Board> ProcessedBoards { get; set; }
//        public IEqualityComparer<Board> IBoardsEqualityComparer { get; set; }

//        public MoveEnum[] MoveOrder { get; set; }   //UDLR
//        public Board SolvedBoard { get; set; }

//        #region InfoFields

//        public List<Board> BoardsVisited = new List<Board>();
//        public int BoardsProcessed { get; set; }
//        public int MaxDepth { get; set; }
//        public InformationStringBuilder InformationToFileBuilder { get; set; }

//        #endregion


//        public override void Solve()
//        {
//            var watch = System.Diagnostics.Stopwatch.StartNew();

//            bool isSolved = false;
//            while (!isSolved)
//            {
//                Board currentBoard = GetNextBoardInStack();
//                if (currentBoard.IsSolved())
//                {
//                    isSolved = true;
//                    SolvedBoard = currentBoard;
//                }
//                else
//                {
//                    InitilizeChildrenBoards(currentBoard);
//                    ProcessedBoards.Add(currentBoard);
//                }
//            }
//            watch.Stop();
//            var elapsedMs = watch.ElapsedMilliseconds;
//            InformationToFileBuilder.FillWithInformation(SolvedBoard.TreeDepth, BoardsVisited.Count, BoardsProcessed, MaxDepth, elapsedMs);
//        }

//        public DFSSolver(Board initBoard, MoveEnum[] moveOrder) : base(initBoard, moveOrder)
//        {
//            MoveOrder = _moveOrder.Reverse().ToArray();     //RLDU
//            InformationToFileBuilder = new InformationStringBuilder();
//            BoardsStack = new Stack<Board>();
//            BoardsStack.Push(initBoard);
//            BoardsProcessed = 1;
//            IBoardsEqualityComparer = new BoardsComparer();
//            ProcessedBoards = new HashSet<Board>(IBoardsEqualityComparer);
//        }

//        public Board GetNextBoardInStack()
//        {
//            while (ProcessedBoards.Contains(BoardsStack.Peek()))
//            {
//                BoardsStack.Pop();
//            }

//            var temp = BoardsStack.Pop();
//            BoardsVisited.Add(temp);
//            return temp;
//        }

//        public override void InitilizeChildrenBoards(Board currentBoard)
//        {
//            if (currentBoard.TreeDepth > MaxDepth)
//            {
//                MaxDepth = currentBoard.TreeDepth;
//            }
//            if (currentBoard.TreeDepth >= 20)
//            {
//                return;
//            }

//            foreach (var allowedMove in currentBoard.GetAllowedMoves(_moveOrder))
//            {
//                Board boardToAddToStack = currentBoard.Shift(allowedMove);

//                if (ProcessedBoards.Contains(boardToAddToStack))
//                    continue;

//                BoardsStack.Push(boardToAddToStack);
//                BoardsProcessed++;
//            }
//        }
//    }
//}
