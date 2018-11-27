using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BoardModel;

namespace FifteenSolvers.Comparer
{
    public class BoardsComparer : IEqualityComparer<Board>
    {
        public bool Equals(Board firstBoard, Board secondBoard)
        {
            byte[,] firstBoardBytes = firstBoard.BoardInstance;
            byte[,] secondBoardBytes = secondBoard.BoardInstance;

            for (int i = 0; i < firstBoard.SizeX; i++)
            {
                for (int j = 0; j < firstBoard.SizeX; j++)
                {
                    if (firstBoardBytes[i, j] != secondBoardBytes[i, j])
                        return false;
                }
            }

            return true;
        }

        public int GetHashCode(Board obj)
        {
            return obj.GetHashCode() * 17;
        }
    }
}
