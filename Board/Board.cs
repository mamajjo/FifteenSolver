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
        public Board(BoardData data)
        {
            boardData = data
                ;
            zeroCell = DetectZeroPosition();
        }
        public Board Shift(MoveEnum moveEnum)
        {
            switch (moveEnum)
            {
                case MoveEnum.U:
                    if (zeroCell.Row == boardData.SizeX)
                    {
                        return new Board(boardData);
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData() {Board = boardData.Board, SizeX = boardData.SizeX, SizeY = boardData.SizeY};
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row - 1,zeroCell.Column];
                        tempBoardData.Board[zeroCell.Row - 1,zeroCell.Column] = 0;
                        return new Board(tempBoardData);

                    }
                case MoveEnum.L:
                    if (zeroCell.Column == 0)
                    {
                        return new Board(boardData);

                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData = boardData;
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row,zeroCell.Column - 1];
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column - 1] = 0;
                        return new Board(tempBoardData);
                    }
                case MoveEnum.D:
                    if (zeroCell.Row == boardData.SizeX)
                    {
                        return new Board(boardData);
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData = boardData;
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row + 1,zeroCell.Column];
                        tempBoardData.Board[zeroCell.Row + 1,zeroCell.Column] = 0;
                        return new Board(tempBoardData);

                    }
                case MoveEnum.R:
                    if (zeroCell.Column == boardData.SizeY)
                    {
                        return new Board(boardData);
                    }
                    else
                    {
                        BoardData tempBoardData = new BoardData();
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column] = boardData.Board[zeroCell.Row,zeroCell.Column + 1];
                        tempBoardData.Board[zeroCell.Row,zeroCell.Column + 1] = 0;
                        return new Board(tempBoardData);

                    }
                default:
                        return new Board(boardData); ;
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
    }
}
