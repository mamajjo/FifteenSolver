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
        public abstract void Solve();
        public BaseSolver()
        {

        }
        public abstract void InitilizeChildrenBoards(Board currentBoard);


    }
}
