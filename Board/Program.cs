using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Board
    {
        List<Cell> board = new List<Cell>();
        public Board(List<Cell> _board)
        {
            board = _board;
        }
    }
}
