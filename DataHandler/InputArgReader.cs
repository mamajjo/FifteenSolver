using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BoardModel;

namespace DataHandler
{
    public class InputArgReader
    {
        //program bfs RDUL 4x4_01_0001.txt 4x4_01_0001_bfs_rdul_sol.txt 4x4_01_0001_bfs_rdul_stats.txt
        public List<MoveEnum> MoveEnums= new List<MoveEnum>();
        public string Algorithm { get; set; }
        public string Strategy { get; set; }
        public string InputBoard { get; set; }
        public string OutputBoard { get; set; }
        public string OutputStats { get; set; }

        public InputArgReader(string[] args)
        {
            Algorithm = args[0];
            Strategy = args[1];
            InputBoard = args[2];
            OutputBoard = args[3];
            OutputStats = args[4];
        }
        public MoveEnum[] GetMoveEnums()
        {
            if (Strategy.Length != 4)
                throw new ArgumentException("Given move order must contain 4 letters");
            MoveEnum[] moveOrder = new MoveEnum[4];
            for (int i = 0; i < 4; i++)
            {
                if (Strategy[i] == 'U' || Strategy[i] == 'u')
                {
                    moveOrder[i] = (MoveEnum.U);
                }
                else if (Strategy[i] == 'D' || Strategy[i] == 'd')
                {
                    moveOrder[i] = (MoveEnum.D);
                }
                else if (Strategy[i] == 'R' || Strategy[i] == 'r')
                {
                    moveOrder[i] = (MoveEnum.R);
                }
                else if (Strategy[i] == 'L' || Strategy[i] == 'l')
                {
                    moveOrder[i] = (MoveEnum.L);
                }
            }
            return moveOrder;
        }
    }
}
