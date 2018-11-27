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
            string[] argss =
            {
                @"dsf", @"ldur", @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001.txt",
                @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001_dfs_ludr_sol.txt",
                @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001_dfs_ludr_stats.txt"
            };

            InputArgReader inputArgReader = new InputArgReader(argss);
            Board testingBoard = new Board(DataLoader.LoadDataFromFile(inputArgReader.InputBoard), new List<MoveEnum>());
            Console.WriteLine(testingBoard.ToString());
            MoveEnum[] lol = {MoveEnum.L, MoveEnum.D, MoveEnum.R, MoveEnum.U};
            BaseSolver solver = new DFSSolver(lol);
            solver.InitializeContainers(testingBoard);
            Board solved = solver.Solve();
            Console.WriteLine(solved.ToString());

            DataSaver.SaveText(solver.InformationToFileBuilder.ToString(), inputArgReader.OutputStats);
            

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
       
    }
}
