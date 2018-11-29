using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace BoardModel
{
    public class Board
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public byte[,] BoardInstance { get; set; }
        public MoveEnum LastMove { get; set; } = MoveEnum.N;
        public int TreeDepth { get; set; }
        public List<MoveEnum> PathToSolution { get; set; }
        public ZeroCell ZeroCell { get; set; }

        public Board(int sizeX, int sizeY, byte[,] board, MoveEnum lastMove, List<MoveEnum> pathToSolution)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            BoardInstance = board;
            LastMove = lastMove;
            PathToSolution = new List<MoveEnum>(pathToSolution) {lastMove};
            TreeDepth = PathToSolution.Count;
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

        public Board(Board boardToInject, List<MoveEnum> pathToSolution, MoveEnum lastMove = MoveEnum.N)
        {
            SizeX = boardToInject.SizeX;
            SizeY = boardToInject.SizeY;
            LastMove = lastMove;
            BoardInstance = boardToInject.BoardInstance;
            PathToSolution = pathToSolution;
            ZeroCell = DetectZeroPosition();
        }

        public Board Shift(MoveEnum moveEnum)
        {
            byte[,] tempBoard = new byte[SizeX, SizeY];
            byte tempValue = 0;
            Array.Copy(BoardInstance, tempBoard, SizeX * SizeY);
            switch (moveEnum)
            {
                case MoveEnum.U:
                    tempValue = tempBoard[ZeroCell.Row - 1, ZeroCell.Column];
                    tempBoard[ZeroCell.Row - 1, ZeroCell.Column] = 0;
                    tempBoard[ZeroCell.Row, ZeroCell.Column] = tempValue;
                    break;

                case MoveEnum.L:
                    tempValue = tempBoard[ZeroCell.Row, ZeroCell.Column - 1];
                    tempBoard[ZeroCell.Row, ZeroCell.Column - 1] = 0;
                    tempBoard[ZeroCell.Row, ZeroCell.Column] = tempValue;
                    break;

                case MoveEnum.D:
                    tempValue = tempBoard[ZeroCell.Row + 1, ZeroCell.Column];
                    tempBoard[ZeroCell.Row + 1, ZeroCell.Column] = 0;
                    tempBoard[ZeroCell.Row, ZeroCell.Column] = tempValue;
                    break;

                case MoveEnum.R:
                    tempValue = tempBoard[ZeroCell.Row, ZeroCell.Column + 1];
                    tempBoard[ZeroCell.Row, ZeroCell.Column + 1] = 0;
                    tempBoard[ZeroCell.Row, ZeroCell.Column] = tempValue;
                    break;
            }

            return new Board(SizeX, SizeY, tempBoard, moveEnum, this.PathToSolution);
        }

        public List<MoveEnum> GetAllowedMoves(MoveEnum[] moveOrder)
        {
            List<MoveEnum> allowedMoves = new List<MoveEnum>();
            for (int i = 0; i < 4; i++)
            {
                if (moveOrder[i] == MoveEnum.D && (ZeroCell.Row == (SizeX - 1) || LastMove == MoveEnum.U))
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.U && (ZeroCell.Row == 0 || LastMove == MoveEnum.D))
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.L && (ZeroCell.Column == 0 || LastMove == MoveEnum.R))
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.R && (ZeroCell.Column == (SizeY - 1) || LastMove == MoveEnum.L))
                {
                    continue;
                }
                allowedMoves.Add(moveOrder[i]);
            }
            return allowedMoves;
        }

        public bool IsSolved()
        {
            int temp = 0;
            //byte[,] correctBoardInstance = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    temp = ((i * SizeX) + j + 1) % (SizeX * SizeY);
                if (BoardInstance[i, j] != temp)
                        return false;
                }
            }

            return true;
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

        public int GetDepthLevel()
        {
            var depthLevel = 0;
            depthLevel += ZeroCell.Column + 1;
            depthLevel += ZeroCell.Row + 1;
            return depthLevel;
        }

        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();
            for (byte i = 0; i < SizeX; i++)
            {
                for (byte j = 0; j < SizeY; j++)
                {
                    sB.Append(BoardInstance[i, j] + " ");
                }
                sB.Append("\r\n");
            }
            return sB.ToString();
        }

        public string PathToSolutionString()
        {
            StringBuilder sb = new StringBuilder();
            PathToSolution.RemoveAt(0);
            sb.AppendLine(PathToSolution.Count.ToString());
            foreach (var move in PathToSolution)
            {
                sb.Append(move.ToString());
            }
            return sb.ToString();
        }

        
    }
}
