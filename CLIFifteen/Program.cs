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
        public MoveEnum[] givenMoveOrder;
        static void Main(string[] args)
        {
            Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard.txt"), GivenMoveOrder(args[1]), null);

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
        private static MoveEnum[] GivenMoveOrder(string moveOrder)
        {
            if (moveOrder.Length != 4)
                throw new ArgumentException("Given move order must contain 4 letters");
            MoveEnum[] moveOrderArray = new MoveEnum[4];
            char letter;
            for (int i = 0; i < 4; i++)
            {
                letter = moveOrder.ElementAt(i);
                if (letter == 'U' || letter == 'u')
                {
                    moveOrderArray[i] = MoveEnum.U;
                }
                else if (letter == 'D' || letter == 'd')
                {
                    moveOrderArray[i] = MoveEnum.D;
                }
                else if (letter == 'R' || letter == 'r')
                {
                    moveOrderArray[i] = MoveEnum.R;
                }
                else if (letter == 'L' || letter == 'l')
                {
                    moveOrderArray[i] = MoveEnum.L;
                }
            }
            return moveOrderArray;
        }
    }
}
