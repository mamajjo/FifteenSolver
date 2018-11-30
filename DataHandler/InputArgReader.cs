using BoardModel;
using System;
using System.Collections.Generic;

namespace DataHandler
{
    public class InputArgReader
    {
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