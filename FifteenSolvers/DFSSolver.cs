using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BoardModel;
using FifteenSolvers.Comparer;

namespace FifteenSolvers
{
    public class DFSSolver : BaseSolver
    {
        public Stack<Board> BoardsStack { get; set; }
        public HashSet<Board> ProcessedBoards { get; set; }
        public IEqualityComparer<Board> IBoardsEqualityComparer { get; set; }
        
        public MoveEnum[] MoveOrder { get; set; }   //UDLR
        public Board SolvedBoard { get; set; }
        public override void Solve()
        {
            bool isSolved = false;
            while (!isSolved)
            {
                Board currentBoard = GetNextBoardInStack();
                if (currentBoard.IsSolved())
                {
                    isSolved = true;
                    SolvedBoard = currentBoard;
                }
                else
                {
                    InitilizeChildrenBoards(currentBoard);

                    ProcessedBoards.Add(currentBoard);
                }
            }
        }

        public DFSSolver(Board initBoard, MoveEnum[] moveOrder)
        {
            _moveOrder = moveOrder;
            MoveOrder = _moveOrder.Reverse().ToArray();     //RLDU
            BoardsStack = new Stack<Board>();
            BoardsStack.Push(initBoard);
            IBoardsEqualityComparer = new BoardsComparer();
            ProcessedBoards = new HashSet<Board>(IBoardsEqualityComparer);
        }

        public Board GetNextBoardInStack()
        {
            while (ProcessedBoards.Contains(BoardsStack.Peek()))
            {
                BoardsStack.Pop();
            }

            return BoardsStack.Pop();
        }

        public override void InitilizeChildrenBoards(Board currentBoard)
        {
            if (currentBoard.TreeDepth >= 20)
            {
                return;
            }

            foreach (var allowedMove in currentBoard.GetAllowedMoves(_moveOrder))
            {
                Board boardToAddToStack = currentBoard.Shift(allowedMove);

                if(ProcessedBoards.Contains(boardToAddToStack))
                    continue;

                BoardsStack.Push(boardToAddToStack);
            }
        }
    }
}
