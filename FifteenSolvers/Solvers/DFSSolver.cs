using BoardModel;
using System.Collections.Generic;
using System.Linq;

namespace FifteenSolvers.Solvers
{
    public class DFSSolver : BaseSolver
    {
        public Stack<Board> BoardsStack { get; set; } = new Stack<Board>();

        public DFSSolver(MoveEnum[] moveOrder)
        {
            MoveOrder = moveOrder.Reverse().ToArray();
        }

        public override void InitializeChildrenBoards(Board currentBoard)
        {
            if (currentBoard.TreeDepth >= 20)
            {
                return;
            }

            foreach (var allowedMove in currentBoard.GetAllowedMoves(MoveOrder))
            {
                Board boardToAddToStack = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToAddToStack))
                    continue;

                BoardsStack.Push(boardToAddToStack);
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            if (BoardsStack.Count == 0)
                CanNotSolve = -1;
            while (HashedBoardsSet.Contains(BoardsStack.Peek()))
            {
                BoardsStack.Pop();
            }

            var temp = BoardsStack.Pop();
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsStack.Push(CurrentBoard);
        }
    }
}