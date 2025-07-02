namespace algorithm.Backtracking;

public class NQueen
{
    // 1. Backtracking (hash set)
    HashSet<int> col = new HashSet<int>();
    HashSet<int> posDiag = new HashSet<int>();
    HashSet<int> negDiag = new HashSet<int>();
    List<List<string>> res = new List<List<string>>();

    public List<List<string>> SolveNQueens(int n)
    {
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        Backtracking(0, n, board);
        return res;
    }

    private void Backtracking(int r, int n, char[][] board)
    {
        if (r == n)
        {
            List<string> copy = new List<string>();
            foreach (char[] row in board)
            {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }

        for (int c = 0; c < n; c++)
        {
            if (col.Contains(c) || posDiag.Contains(r + c)
            || negDiag.Contains(r - c))
            {
                continue;
            }

            col.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            Backtracking(r + 1, n, board);

            col.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }
}