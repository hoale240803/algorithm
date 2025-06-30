
namespace algorithm.Backtracking;

public class WordSearch
{
    // Backtracking (Hash Set)
    private int ROWS, COLS;
    private HashSet<(int, int)> path = new HashSet<(int, int)>();
    public bool Exist(char[][] board, string word)
    {
        ROWS = board.Length;
        COLS = board[0].Length;

        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                if (DFS(board, word, r, c, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int i)
    {
        if (i == word.Length)
        {
            return true;
        }

        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || board[r][c] != word[i] || path.Contains((r, c)))
        {
            return false;
        }

        path.Add((r, c));
        bool res = DFS(board, word, r + 1, c, i + 1) ||
        DFS(board, word, r - 1, c, i + 1) ||
        DFS(board, word, r, c + 1, i + 1) ||
        DFS(board, word, r, c - 1, i + 1);
        path.Remove((r, c));


        return res;
    }

    // Backtracking optimize
    private int rows1, col1;

    public bool Exist1(char[][] board, string word)
    {
        rows1 = board.Length;
        col1 = board[0].Length;

        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                if (DFS1(board, word, r, c, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool DFS1(char[][] board, string word, int r, int c, int i)
    {

        if (i == word.Length)
        {
            return true;
        }

        if (r < 0 || c < 0 || r >= ROWS || r >= ROWS || c >= COLS ||
        board[r][c] != word[i] || board[r][c] == '#')
        {
            return false;
        }

        board[r][c] = '#';
        bool res = DFS1(board, word, r + 1, c, i + 1);
        DFS1(board, word, r - 1, c, i + 1);
        DFS1(board, word, r, c + 1, i + 1);
        DFS1(board, word, r, c - 1, i + 1);

        board[r][c] = word[i];
        return res;
    }
}