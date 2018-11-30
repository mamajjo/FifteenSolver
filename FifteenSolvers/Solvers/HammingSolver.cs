using BoardModel;
using Priority_Queue;

namespace FifteenSolvers.Solvers
{
    public class HammingSolver : BaseSolver
    {
        public SimplePriorityQueue<Board, int> BoardsQueue { get; set; } = new SimplePriorityQueue<Board, int>();

        public HammingSolver(MoveEnum[] moveOrder)
        {
            MoveOrder = moveOrder;
        }

        public override void InitializeChildrenBoards(Board currentBoard)
        {
            foreach (var allowedMove in currentBoard.GetAllowedMoves(MoveOrder))
            {
                Board boardToEnqueue = currentBoard.Shift(allowedMove);

                if (HashedBoardsSet.Contains(boardToEnqueue))
                    continue;

                BoardsQueue.Enqueue(boardToEnqueue, CurrentBoard.TreeDepth + HeuristicFunction(boardToEnqueue));
                BoardsProcessed++;
            }
        }

        public override Board GetNextBoardInContainer()
        {
            var test = BoardsQueue.GetPriority(BoardsQueue.First);
            var temp = BoardsQueue.Dequeue();

            return temp;
        }

        public override void InitializeContainers(Board initialBoard)
        {
            CurrentBoard = initialBoard;
            BoardsQueue.Enqueue(CurrentBoard, CurrentBoard.TreeDepth + HeuristicFunction(CurrentBoard));
        }

        private int HeuristicFunction(Board board)
        {
            Board boardToCheck = board;
            int distance = 0;

            for (int i = 0; i < boardToCheck.SizeX; i++)
            {
                for (int j = 0; j < boardToCheck.SizeY; j++)
                {
                    distance += (boardToCheck.BoardInstance[i, j] != ((i * boardToCheck.SizeX) + j + 1) % (boardToCheck.SizeX * boardToCheck.SizeY)) ? 1 : 0;
                }
            }
            return distance;
        }
    }
}