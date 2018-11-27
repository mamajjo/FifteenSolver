using BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenSolvers
{
    public abstract class BaseSolver
    {
        public MoveEnum[] _moveOrder;
        protected Board _initBoard;
        public abstract void Solve();

        protected BaseSolver(Board initBoard, MoveEnum[] moveOrder)
        {
            _initBoard = initBoard;
            _moveOrder = moveOrder;
        }
        public abstract void InitilizeChildrenBoards(Board currentBoard);


    }
}
