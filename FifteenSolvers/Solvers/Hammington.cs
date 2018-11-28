using System;
using System.Linq;
using BoardModel;
using Priority_Queue;

namespace FifteenSolvers.Solvers
{
    public class Hammington : BaseSolver 
    {
        public SimplePriorityQueue<Board> BoardsQueue { get; set; } = new SimplePriorityQueue<Board>();

        public Hammington(MoveEnum[] moveOrder)
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
                Board boardToEnqueue = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToEnqueue))
                    continue;

                BoardsQueue.Enqueue(boardToEnqueue, HeuristicFunction(boardToEnqueue));
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            while (HashedBoardsSet.Contains(BoardsQueue.Last()))
            {
                BoardsQueue.Dequeue();
            }

            var temp = BoardsQueue.Dequeue();
            BoardsVisited.Add(temp);
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            InitBoard = initialBoard;
            BoardsQueue.Enqueue(InitBoard, HeuristicFunction(InitBoard));
        }

        public override bool IsContainerEmpty()
        {
            return (BoardsQueue.Count == 0);
        }
        private int HeuristicFunction(Board board)
        {
            Board boardToCheck = board;
            int distance = boardToCheck.GetDepthLevel();

            for (int i = 0; i < boardToCheck.SizeX; i++)
            {
                for (int j = 0; j < boardToCheck.SizeY; j++)
                {
                    distance += boardToCheck.BoardInstance[i, j] != (j + i) * i + 1 ? 1 : 0;
                }
            }
            return distance;
        }
    }
}