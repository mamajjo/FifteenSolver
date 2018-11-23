using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Board
    {
        byte[][] board;
        public byte Rows { get; set; }
        public byte Columns { get; set; }
        Cell zeroCell;
        public Board(byte[][] _board)
        {
            board = _board;
            zeroCell = DetectZeroPosition();
        }
        public Board Shift(MoveEnum moveEnum)
        {
            switch (moveEnum)
            {
                case MoveEnum.U:
                    if (zeroCell.Row == 0)
                    {
                        return new Board(board);
                    }
                    else
                    {
                        byte[][] temp = board;
                        temp[zeroCell.Row][zeroCell.Column] = board[zeroCell.Row - 1][zeroCell.Column];
                        temp[zeroCell.Row - 1][zeroCell.Column] = 0;
                        return new Board(temp);
                    }
                case MoveEnum.L:
                    if (zeroCell.Column == 0)
                    {
                        return new Board(board);
                    }
                    else
                    {
                        byte[][] temp = board;
                        temp[zeroCell.Row][zeroCell.Column] = board[zeroCell.Row][zeroCell.Column - 1];
                        temp[zeroCell.Row][zeroCell.Column - 1] = 0;
                        return new Board(temp);
                    }
                case MoveEnum.D:
                    if (zeroCell.Row == 3)
                    {
                        return new Board(board);
                    }
                    else
                    {
                        byte[][] temp = board;
                        temp[zeroCell.Row][zeroCell.Column] = board[zeroCell.Row + 1][zeroCell.Column];
                        temp[zeroCell.Row + 1][zeroCell.Column] = 0;
                        return new Board(temp);
                    }
                case MoveEnum.R:
                    if (zeroCell.Column == 3)
                    {
                        return new Board(board);
                    }
                    else
                    {
                        byte[][] temp = board;
                        temp[zeroCell.Row][zeroCell.Column] = board[zeroCell.Row][zeroCell.Column + 1];
                        temp[zeroCell.Row][zeroCell.Column + 1] = 0;
                        return new Board(temp);
                    }
                default:
                    return new Board(board);
            }
        }
        public Cell DetectZeroPosition()
        {
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Columns; j++)
                {
                    if (board[i][j] == 0)
                        return new Cell(i, j);
                }
            }
            return null;
        }
    }
}
