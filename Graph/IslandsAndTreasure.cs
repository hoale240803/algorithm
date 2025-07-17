namespace algorithm.Graph;

public class IslandsAndTreasureClass
{
    private int[][] directions = new int[][]
    {
        new int[] { 0, 1 }, // right
        new int[] { 1, 0 }, // down
        new int[] { 0, -1 }, // left
        new int[] { -1, 0 } // up
    };

    private int INF = 2147483647;
    private bool[,] visit;
    private int rows, cols;

    public int Dfs(int[][] grid, int r, int c)
    {
        if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == -1 || visit[r, c])
        {
            return INF;
        }

        if (grid[r][c] == 0)
        {
            return 0;
        }

        visit[r, c] = true;
        int res = INF;

        foreach (var dir in directions)
        {
            int cur = Dfs(grid, r + dir[0], c + dir[1]);

            if (cur != INF)
            {
                res = Math.Min(res, 1 + cur);
            }
        }

        visit[r, c] = false;
        return res;
    }

    public void islandsAndTreasure(int[][] grid)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        visit = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == INF)
                {
                    grid[r][c] = Dfs(grid, r, c);
                }
            }
        }
    }

    // Multi source BFS

    public void islandsAndTreasure2(int[][] grid)
    {
        Queue<int[]> q = new Queue<int[]>();
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0) q.Enqueue(new int[] { i, j });
            }
        }

        if (q.Count == 0) return;
        int[][] dirs = {
            new int[] {-1,0}, new int []{0, -1},
            new int[]{1, 0}, new int[] {0, 1}
        };
        while (q.Count > 0)
        {
            int[] cur = q.Dequeue();
            int row = cur[0];
            int col = cur[1];
            foreach (int[] dir in dirs)
            {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r >= m || c >= n || r < 0 || c < 0 || grid[r][c] != int.MaxValue)
                {
                    continue;
                }

                q.Enqueue(new int[] { r, c });
                grid[r][c] = grid[row][col] + 1;
            }
        }
    }
}