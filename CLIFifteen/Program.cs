using DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardModel;
using FifteenSolvers;

namespace CLIFifteen
{
    class Program
    {
        //public static Queue<MoveEnum> givenMoveOrder = new Queue<MoveEnum>();
        static void Main(string[] args)
        {
            Board testingBoard = new Board(DataLoader.LoadDataFromFile("C:\\Users\\Maciej\\source\\repos\\FifteenSolver\\UnitTests\\testBoard.txt"), new List<MoveEnum>());
            Console.WriteLine(testingBoard.ToString());
            MoveEnum[] lol = {MoveEnum.L, MoveEnum.D, MoveEnum.R, MoveEnum.U};
            BaseSolver solver = new DFSSolver(lol);
            solver.InitializeContainers(testingBoard);
            Board solved = solver.Solve();
            Console.WriteLine(solved.ToString());

            DataSaver.SaveText(solver.InformationToFileBuilder.ToString(), @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\info.txt");
            

            //testingBoard.Shift(MoveEnum.U);
            //Console.WriteLine(testingBoard.ToString());
            //Console.Read();
            //List<Board> boards = new List<Board>();
            //boards.Add(testingBoard);
            //boards.Add(testingBoard.Shift(MoveEnum.U));
            //foreach (var item in boards)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            Console.ReadKey();
        }
        Queue<MoveEnum> GivenMoveOrder(string moveOrder)
        {
            if (moveOrder.Length != 4)
                throw new ArgumentException("Given move order must contain 4 letters");
            Queue<MoveEnum> moveOrderQueue = new Queue<MoveEnum>();
            char letter;
            for (int i = 0; i < 4; i++)
            {
                letter = moveOrder.ElementAt(i);
                if (letter == 'U' || letter == 'u')
                {
                    moveOrderQueue.Enqueue(MoveEnum.U);
                }
                else if (letter == 'D' || letter == 'd')
                {
                    moveOrderQueue.Enqueue(MoveEnum.D);
                }
                else if (letter == 'R' || letter == 'r')
                {
                    moveOrderQueue.Enqueue(MoveEnum.R);
                }
                else if (letter == 'L' || letter == 'l')
                {
                    moveOrderQueue.Enqueue(MoveEnum.L);
                }
            }
            return moveOrderQueue;
        }
    }
}
