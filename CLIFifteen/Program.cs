using DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardModel;
using FifteenSolvers;
using FifteenSolvers.Solvers;

namespace CLIFifteen
{
    class Program
    {
        //public static Queue<MoveEnum> givenMoveOrder = new Queue<MoveEnum>();
        static void Main(string[] args)
        {
            //string[] argss =
            //{
            //    @"astr", @"hamm", @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001.txt",
            //    @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001_dfs_ludr_sol.txt",
            //    @"C:\Users\Maciej\source\repos\FifteenSolver\UnitTests\4x4_01_0001_dfs_ludr_stats.txt"
            //};

            InputArgReader inputArgReader = new InputArgReader(args);
            Board testingBoard = new Board(DataLoader.LoadDataFromFile(inputArgReader.InputBoard), new List<MoveEnum>());
            MoveEnum[] lol = {MoveEnum.L, MoveEnum.D, MoveEnum.R, MoveEnum.U};
            BaseSolver solver = null;
            
           
            
            //select algorithm depending on input arguments
            switch (inputArgReader.Algorithm)
            {
                case "dfs":
                    solver = new DFSSolver(inputArgReader.GetMoveEnums());
                    break;
                case "bfs":
                    solver = new BFSSolver(inputArgReader.GetMoveEnums());
                    break;
                case "astr":
                    switch (inputArgReader.Strategy)
                    {
                        case "manh":
                            solver = new Manhattan(lol);
                            break;
                        case "hamm":
                            solver = new Hammington(lol);
                            break;
                            default:
                                break;
                                
                    }
                    break;
                default:
                    break;
                    
            }
            solver.InitializeContainers(testingBoard);
            Board solved = solver.Solve();
            DataSaver.SaveText(solved.PathToSolutionString(), inputArgReader.OutputBoard);
            DataSaver.SaveText(solver.InformationToFileBuilder.ToString(), inputArgReader.OutputStats);
        }
       
    }
}
