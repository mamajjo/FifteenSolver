
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardModel
{
    public class Cell
    {
        public byte Row { get; set; }
        public byte Column { get; set; }
    
        public Cell(Cell cellToCopy)
        {
            Row = cellToCopy.Row;
            Column = cellToCopy.Column;
        }
        public Cell(byte r, byte c)
        {
            Row = r;
            Column = c; 
        }

    }
}
