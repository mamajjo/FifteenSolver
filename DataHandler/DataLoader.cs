using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataHandler
{
    //klasa do wczytywaniu z pliku po podaniu ścieżki do niej
    //klasa układanki i jej stanu string[w][k]
    public class DataLoader
    {
        public static byte[,] LoadDataFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string temp = sr.ReadLine();
                string[] parts = temp.Split(' ');
                byte sizeX = Byte.Parse(parts[0]);
                byte sizeY = Byte.Parse(parts[1]);
                byte[,] board =new byte[sizeX, sizeY];

                for (int x = 0; x < sizeX; x++)
                {
                    temp = sr.ReadLine();
                    parts = temp.Split(' ');
                    for (int y = 0; y < sizeY; y++)
                    {
                        board[x, y] = Byte.Parse(parts[y]);
                    }
                }

                return board;
            }
        }
    }
}
