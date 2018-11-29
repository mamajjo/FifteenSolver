using System.Collections.Generic;
using BoardModel;

namespace FifteenSolvers.Solvers
{
    public class BFSSolver: BaseSolver
    {
        public Queue<Board> BoardsQueue { get; set; } = new Queue<Board>();

        public BFSSolver(MoveEnum[] moveOrder)
        {
            MoveOrder = moveOrder;
        }
        public override void InitializeChildrenBoards(Board currentBoard)
        {
            if (currentBoard.TreeDepth > MaxDepth)
            {
                MaxDepth = currentBoard.TreeDepth;
            }
            if (currentBoard.TreeDepth >= 20)
            {
                return;
            }

            foreach (var allowedMove in currentBoard.GetAllowedMoves(MoveOrder))
            {
                Board boardToAddToEnqueue = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToAddToEnqueue))
                    continue;

                BoardsQueue.Enqueue(boardToAddToEnqueue);
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            while (HashedBoardsSet.Contains(BoardsQueue.Peek()))
            {
                BoardsQueue.Dequeue();
            }

            var temp = BoardsQueue.Dequeue();
            BoardsVisited.Add(temp);
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsQueue.Enqueue(CurrentBoard);
        }

        public override bool IsContainerEmpty()
        {
            return (BoardsQueue.Count == 0);
        }
    }
}