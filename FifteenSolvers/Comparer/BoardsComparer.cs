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
            byte[,] state = obj.BoardInstance;
            if (state == null) return 0;
            if (state.Length == 0) return -1;
            //unchecked
            //{
            //    const int p = 16777619;
            //    int hash = (int)2166136261;

            //    for (int i = 0; i < state.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < state.GetLength(1); j++)
            //        {
            //            hash = (hash ^ state[i, j] ^ i ^ j) * p;
            //        }
            //    }

            //    hash += hash << 13;
            //    hash ^= hash >> 7;
            //    hash += hash << 3;
            //    hash ^= hash >> 17;
            //    hash += hash << 5;

            //    return hash;
            //}

            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, obj) ? obj.GetHashCode() : 0);

                for (int i = 0; i < state.GetLength(0); i++)
                {
                    for (int j = 0; j < state.GetLength(1); j++)
                    {
                        hash = (hash ^ state[i, j] ^ i ^ j) * HashingBase;
                    }
                }
                return hash;
            }
        }
    }
}
