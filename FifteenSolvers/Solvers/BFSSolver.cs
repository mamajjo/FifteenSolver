﻿using BoardModel;
using System.Collections.Generic;

namespace FifteenSolvers.Solvers
{
    public class BFSSolver : BaseSolver
    {
        public Queue<Board> BoardsQueue { get; set; } = new Queue<Board>();

        public BFSSolver(MoveEnum[] moveOrder)
        {
            MoveOrder = moveOrder;
        }

        public override void InitializeChildrenBoards(Board currentBoard)
        {
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
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsQueue.Enqueue(CurrentBoard);
        }
    }
}