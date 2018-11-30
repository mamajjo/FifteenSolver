using BoardModel;
using DataHandler;
using FifteenSolvers;
using FifteenSolvers.Solvers;
using System.Collections.Generic;

namespace CLIFifteen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InputArgReader inputArgReader = new InputArgReader(args);
            Board testingBoard = new Board(DataLoader.LoadDataFromFile(inputArgReader.InputBoard), new List<MoveEnum>());
            MoveEnum[] moveEnums = { MoveEnum.L, MoveEnum.D, MoveEnum.R, MoveEnum.U };
            BaseSolver solver = null;

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
                        case "hamm":
                            solver = new HammingSolver(moveEnums);
                            break;

                        case "manh":
                            solver = new ManhattanSolver(moveEnums);
                            break;
                    }

                    break;
            }
            solver.InitializeContainers(testingBoard);
            Board solved = solver.Solve();
            DataSaver.SaveText(solved.PathToSolutionString(), inputArgReader.OutputBoard);
            DataSaver.SaveText(solver.InformationToFileBuilder.ToString(), inputArgReader.OutputStats);
        }
    }
}