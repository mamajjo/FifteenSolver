﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BoardModel;
using DataHandler;
using FifteenSolvers.Comparer;

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
                Board boardToAddToStack = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToAddToStack))
                    continue;

                BoardsStack.Push(boardToAddToStack);
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            while (HashedBoardsSet.Contains(BoardsStack.Peek()))
            {
                BoardsStack.Pop();
            }

            var temp = BoardsStack.Pop();
            BoardsVisited.Add(temp);
            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            InitBoard = initialBoard;
            BoardsStack.Push(InitBoard);
           // HashedBoardsSet.Add(InitBoard);
        }

        public override bool IsContainerEmpty()
        {
            return (BoardsStack.Count == 0);
        }
    }
}
