using BoardModel;
using Priority_Queue;
using System;

namespace FifteenSolvers.Solvers
{
    public class ManhattanSolver : BaseSolver
    {
        public SimplePriorityQueue<Board> BoardsQueue { get; set; } = new SimplePriorityQueue<Board>();

        public ManhattanSolver(MoveEnum[] moveOrder)
        {
            MoveOrder = moveOrder;
        }

        public override void InitializeChildrenBoards(Board currentBoard)
        {
            foreach (var allowedMove in currentBoard.GetAllowedMoves(MoveOrder))
            {
                Board boardToEnqueue = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToEnqueue))
                    continue;

                BoardsQueue.Enqueue(boardToEnqueue, boardToEnqueue.TreeDepth + HeuristicFunction(boardToEnqueue));
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            var temp = BoardsQueue.Dequeue();
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsQueue.Enqueue(CurrentBoard, CurrentBoard.TreeDepth + HeuristicFunction(CurrentBoard));
        }

        private int HeuristicFunction(Board board)
        {
            Board boardToCheck = board;
            int distance = boardToCheck.GetDepthLevel();

            for (int i = 0; i < boardToCheck.SizeX; i++)
            {
                for (int j = 0; j < boardToCheck.SizeY; j++)
                {
                    int value = board.BoardInstance[i, j];
                    if (value != 0)
                    {
                        int x = (value - 1) % boardToCheck.SizeX;
                        int y = (value - 1 - x) / boardToCheck.SizeY;
                        distance += Math.Abs(j - x) + Math.Abs(i - y);
                    }
                }
            }

            return distance;
        }
    }
}