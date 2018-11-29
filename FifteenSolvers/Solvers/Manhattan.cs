using System;
using System.Collections.Generic;
using System.Linq;
using BoardModel;
using Priority_Queue;

namespace FifteenSolvers.Solvers
{
    public class Manhattan: BaseSolver
    {
        public SimplePriorityQueue<Board> BoardsQueue { get; set; } = new SimplePriorityQueue<Board>();

        public Manhattan(MoveEnum[] moveOrder)
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
                    int value = board.BoardInstance[i,j];
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