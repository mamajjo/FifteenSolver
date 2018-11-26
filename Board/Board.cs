using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardModel;
using DataHandler;

namespace BoardModel
{
    public class Board
    {
        byte[,] board;

        Cell zeroCell;
        BoardData boardData { get; set; }
        Queue<MoveEnum> moveEnums = new Queue<MoveEnum>();
        MoveEnum lastMove = new MoveEnum();
        public List<MoveEnum> PathToSolution { get; set; }
        Board _parent;
        public Board(int sizeX, int sizeY, byte[,] board, Board parent)
        {
            boardData.SizeX = (byte)sizeX;
            boardData.SizeY = (byte)sizeY;
            boardData.Board = board;
            _parent = parent;
        }
        public Board(BoardData bD, MoveEnum[] moveOrder, Board parent)
        {
            boardData = bD;
            _parent = parent;
        }
        public Board Shift(MoveEnum moveEnum)
        {
            switch (moveEnum)
            {
                case MoveEnum.U:
                    if (zeroCell.Row == boardData.SizeX)
                    {
                        return this;
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData() {Board = boardData.Board, SizeX = boardData.SizeX, SizeY = boardData.SizeY};
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row - 1,zeroCell.Column];
                        tempBoardData.Board[zeroCell.Row - 1,zeroCell.Column] = 0;
                        lastMove = MoveEnum.U;
                        return new Board(tempBoardData, moveOrder,this);

                    }
                case MoveEnum.L:
                    if (zeroCell.Column == 0)
                    {
                        return this;

                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData = boardData;
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row,zeroCell.Column - 1];
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column - 1] = 0;
                        lastMove = MoveEnum.L;
                        return new Board(tempBoardData, this);
                    }
                case MoveEnum.D:
                    if (zeroCell.Row == boardData.SizeX)
                    {
                        return this;
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData = boardData;
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row + 1,zeroCell.Column];
                        tempBoardData.Board[zeroCell.Row + 1,zeroCell.Column] = 0;
                        lastMove = MoveEnum.D;
                        return new Board(tempBoardData, this);

                    }
                case MoveEnum.R:
                    if (zeroCell.Column == boardData.SizeY)
                    {
                        return this;
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row,zeroCell.Column + 1];
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column + 1] = 0;
                        lastMove = MoveEnum.R;
                        return new Board(tempBoardData, this);
                    }
                default:
                        return this;
            }
        } 
        public Cell DetectZeroPosition()
        {
            for (byte i = 0; i < boardData.SizeX; i++)
            {
                for (byte j = 0; j < boardData.SizeY; j++)
                {
                    if (boardData.Board[i,j] == 0)
                        return new Cell(i, j);
                }
            }
            return null;
        }
        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();
            for (byte i = 0; i < boardData.SizeX; i++)
            {
                for (byte j = 0; j < boardData.SizeY; j++)
                {
                    sB.Append(boardData.Board[i, j] + " ");
                }
                sB.Append("\r\n");
            }
            return sB.ToString();
        }
        //should data reference to cli program? if not then change static moveOrder -> passable
        public List<MoveEnum> GetAllowedMoves(MoveEnum[] moveOrder)
        {
            List<MoveEnum> allowedMoves = new List<MoveEnum>();
            for (int i = 0; i < 4; i++)
            {
                if (moveOrder[i] == MoveEnum.D && zeroCell.Column == boardData.SizeX && PathToSolution.Last() == MoveEnum.U)
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.U && zeroCell.Column == 0 && PathToSolution.Last() == MoveEnum.D)
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.L && zeroCell.Column == 0 && PathToSolution.Last() == MoveEnum.L)
                {
                    continue;
                }
                if (moveOrder[i] == MoveEnum.R && zeroCell.Column == boardData.SizeY && PathToSolution.Last() == MoveEnum.R)
                {
                    continue;
                }
                allowedMoves.Add(moveOrder[i]);
            }
            return allowedMoves;
        }
    }
}
