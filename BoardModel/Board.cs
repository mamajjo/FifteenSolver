using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardModel
{
    public class Board
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public byte[,] BoardInstance { get; set; }
        public MoveEnum LastMove { get; set; }
        public List<MoveEnum> PathToSolution { get; set; }
        public ZeroCell ZeroCell { get; set; }

        public Board(int sizeX, int sizeY, byte[,] board, MoveEnum lastMove, List<MoveEnum> pathToSolution)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            BoardInstance = board;
            LastMove = lastMove;
            PathToSolution = new List<MoveEnum>(pathToSolution) {lastMove};
            ZeroCell = DetectZeroPosition();
        }

        public Board(int sizeX, int sizeY, byte[,] board)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            BoardInstance = board;
            PathToSolution = new List<MoveEnum>();
            LastMove = MoveEnum.N;
            ZeroCell = DetectZeroPosition();
        }

        public void Shift(MoveEnum moveEnum)
        {
            byte[,] tempBoard = new byte[SizeX, SizeY];
            Array.Copy(BoardInstance, tempBoard, SizeX * SizeY);
            switch (moveEnum)
            {
                case MoveEnum.U:
                    break;
                case MoveEnum.L:
                    break;
                case MoveEnum.D:
                    break;
                case MoveEnum.R:
                    break;
            }
        } 
        public ZeroCell DetectZeroPosition()
        {
            for (byte i = 0; i < SizeX; i++)
            {
                for (byte j = 0; j < SizeY; j++)
                {
                    if (BoardInstance[i,j] == 0)
                        return new ZeroCell(i, j);
                }
            }
            return null;
        }
        //public override string ToString()
        //{
        //    StringBuilder sB = new StringBuilder();
        //    for (byte i = 0; i < boardData.SizeX; i++)
        //    {
        //        for (byte j = 0; j < boardData.SizeY; j++)
        //        {
        //            sB.Append(boardData.Board[i, j] + " ");
        //        }
        //        sB.Append("\r\n");
        //    }
        //    return sB.ToString();
        //}
    }
}
