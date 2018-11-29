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
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsQueue.Enqueue(CurrentBoard, HeuristicFunction(CurrentBoard));
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
                    distance += (boardToCheck.BoardInstance[i, j] != ((i * boardToCheck.SizeX) + j + 1) % (boardToCheck.SizeX * boardToCheck.SizeY)) ? 1 : 0;
                }
            }
            return distance;
        }
    }
}