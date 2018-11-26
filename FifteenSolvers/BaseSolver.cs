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
        public IEnumerable<Board> BoardsCollection { get; set; }
        public MoveEnum[] _moveOrder;
        public abstract bool Solve();
        public BaseSolver()
        {

        }
        public abstract void InitilizeChildrenBoards();


    }
}
