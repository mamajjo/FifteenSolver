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
            throw new System.NotImplementedException();
        }

        public override Board GetNextBoardInContainer()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeContainers(Board initialBoard)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsContainerEmpty()
        {
            throw new System.NotImplementedException();
        }
    }
}