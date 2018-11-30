using BoardModel;
using System;
using System.IO;

namespace DataHandler
{
    public class DataLoader
    {
        public static Board LoadDataFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string temp = sr.ReadLine();
                string[] parts = temp.Split(' ');
                byte sizeX = Byte.Parse(parts[0]);
                byte sizeY = Byte.Parse(parts[1]);
                byte[,] board = new byte[sizeX, sizeY];

                for (int x = 0; x < sizeX; x++)
                {
                    temp = sr.ReadLine();
                    parts = temp.Split(' ');
                    for (int y = 0; y < sizeY; y++)
                    {
                        board[x, y] = Byte.Parse(parts[y]);
                    }
                }

                return new Board(sizeX, sizeY, board);
            }
        }
    }
}