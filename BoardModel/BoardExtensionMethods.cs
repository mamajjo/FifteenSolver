using System.Text;

namespace BoardModel
{
    public static class BoardExtensionMethods
    {
        public static string BoardToString(this byte[,] board)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    sb.Append(board[i, j] + " ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}