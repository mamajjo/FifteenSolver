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
            Console.WriteLine(testingBoard.ToString());

            testingBoard.Shift(MoveEnum.U);
            Console.WriteLine(testingBoard.ToString());
            Console.Read();
            List<Board> boards = new List<Board>();
            boards.Add(testingBoard);
            boards.Add(testingBoard.Shift(MoveEnum.U));
            foreach (var item in boards)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
