using BoardModel;
using DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard.txt"));
            testingBoard.Shift(MoveEnum.D);
            Console.WriteLine(testingBoard.ToString());
            Console.Read();
        }
    }
}
