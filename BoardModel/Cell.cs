using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardModel
{
    public class ZeroCell
    {
        public byte Row { get; set; }
        public byte Column { get; set; }
    
        public ZeroCell(ZeroCell cellToCopy)
        {
            Row = cellToCopy.Row;
            Column = cellToCopy.Column;
        }
        public ZeroCell(byte r, byte c)
        {
            Row = r;
            Column = c; 
        }

    }
}
