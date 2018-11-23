using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public class BoardData
    {
        public byte[,] Board { get; set; }
        public byte SizeX { get; set; }
        public byte SizeY { get; set; }
    }
}
