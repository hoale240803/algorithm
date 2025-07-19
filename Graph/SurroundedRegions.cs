
namespace algorithm.Graph;

public class SurroundedRegions
{
    // Depth first search
    private int rows, cols;
    public void Solve(char[][] board)
    {
        rows = board.Length;
        cols = board[0].Length;

        for (int r = 0; r < rows; r++)
        {
            if (board[r][0] == 'O')
            {
                Capture(board, r, 0);
            }

            if (board[r][cols - 1] == 'O')
            {
                Capture(board, r, cols - 1);
            }
        }

        for (int c = 0; c < cols; c++)
        {
            if (board[0][c] == 'O')
            {
                Capture(board, 0, c);
            }

            if (board[rows - 1][c] == 'O')
            {
                Capture(board, rows - 1, c);
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O')
                {
                    board[r][c] = 'X';
                }
                else if (board[r][c] == 'T')
                {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void Capture(char[][] board, int r, int c)
    {
        if (r < 0 || c < 0 || r == rows || c == cols || board[r][c] != 'O')
        {
            return;
        }

        board[r][c] = 'T';
        Capture(board, r + 1, c);
        Capture(board, r - 1, c);
        Capture(board, r, c + 1);
        Capture(board, r, c - 1);
    }
}