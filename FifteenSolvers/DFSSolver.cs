using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BoardModel;

namespace FifteenSolvers
{
    public class DFSSolver : BaseSolver
    {
        public Stack<Board> BoardsStack { get; set; }
        public MoveEnum[] MoveOrder { get; set; }   //UDLR
        public Board SolvedBoard { get; set; }
        public int MaxDepth { get; set; }
        public override void Solve()
        {
            bool isSolved = false;
            while (!isSolved)
            {
                Board currentBoard = GetNextBoardInStack();
                if (currentBoard.IsSolved())
                {
                    isSolved = true;
                    SolvedBoard = currentBoard;
                }
                else
                {
                    InitilizeChildrenBoards(currentBoard);
                }
            }
        }

        public DFSSolver(Board initBoard, MoveEnum[] moveOrder):base()
        {
            _moveOrder = moveOrder;
            MoveOrder = _moveOrder.Reverse().ToArray();     //RLDU
            MaxDepth = 0;
            BoardsStack = new Stack<Board>();
            BoardsStack.Push(initBoard);
        }

        public Board GetNextBoardInStack()
        {
           return BoardsStack.Pop();
        }

        public override void InitilizeChildrenBoards(Board currentBoard)
        {
            if (currentBoard.TreeDepth > 20)
            {
                BoardsStack.Pop();
            }

            foreach (var allowedMove in currentBoard.GetAllowedMoves(_moveOrder))
            {
                //TODO CHECK CZY OBECNIE DODAWANY PUSH, NIE BYL JUZ KIEDYS SPRAWDZANY
                BoardsStack.Push(currentBoard.Shift(allowedMove));
            }
        }
    }
}
