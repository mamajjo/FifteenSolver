using BoardModel;
using System.Collections.Generic;

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
            byte[,] state = obj.BoardInstance;
            if (state == null) return 0;
            if (state.Length == 0) return -1;

            unchecked
            {
                const int hashingBase = (int)2166136261;
                const int hashingMultiplier = 16777619;

                int hash = hashingBase;
                hash = (hash * hashingMultiplier) ^ (obj.GetHashCode());

                for (int i = 0; i < state.GetLength(0); i++)
                {
                    for (int j = 0; j < state.GetLength(1); j++)
                    {
                        hash = (hash ^ state[i, j] ^ i ^ j) * hashingBase;
                    }
                }
                return hash;
            }
        }
    }
}