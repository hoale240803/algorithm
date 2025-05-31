namespace algorithm.DP;

public class LongestIncreasingPathDP
{
    private static int[][] directions = new int[][]{
        new int[] {-1, 0}, new int[]{1, 0},
        new int[] {0, -1}, new int[]{0,1}
    };

    private int Dfs(int[][] matrix, int r, int c, int previousValue)
    {
        int rows = matrix.Length, columns = matrix[0].Length;

        if (r < 0 || r >= rows || c < 0 || c >= columns || matrix[r][c] <= previousValue)
        {
            return 0;
        }

        int res = 1;

        foreach (var direction in directions)
        {
            res = Math.Max(res, 1 + Dfs(matrix, r + direction[0], c + direction[1], matrix[r][c]));
        }

        return res;
    }

    // Recursion
    public int LongestIncreasingPath(int[][] matrix)
    {
        int rows = matrix.Length, columns = matrix[0].Length;
        int lip = 0; // longest increasing path;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                lip = Math.Max(lip, Dfs(matrix, r, c, int.MinValue));
            }
        }

        return lip;
    }

    int[,] dp;

    private int Dfs2(int[][] matrix, int r, int c, int previousValue)
    {
        int rows = matrix.Length, columns = matrix[0].Length;

        if (r < 0 || r >= rows || c < 0 || c >= columns || matrix[r][c] <= previousValue)
        {
            return 0;
        }

        if (dp[r, c] != -1) return dp[r, c];

        int res = 1;

        foreach (int[] direction in directions)
        {
            res = Math.Max(res, 1 + Dfs2(matrix, r + direction[0], c + direction[1], matrix[r][c]));
        }

        dp[r, c] = res;

        return res;
    }

    public int LongestIncreasingPath2(int[][] matrix)
    {
        int rows = matrix.Length, columns = matrix[0].Length;

        dp = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                dp[i, j] = -1;
            }
        }

        int lip = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                lip = Math.Max(lip, Dfs2(matrix, r, c, int.MinValue));
            }
        }

        return lip;
    }

    public int LongestIncreasingPath3(int[][] matrix)
    {
        int rows = matrix.Length, columns = matrix[0].Length;

        int[][] indegree = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            indegree[i] = new int[columns];
        }

        int[][] directions = new int[][]{
            new int[]{-1,0}, new int []{ 1, 0},
            new int[]{0,-1}, new int []{0,1}
        };

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                foreach (var d in directions)
                {
                    int newRow = r + d[0], newColumn = c + d[1];

                    if (newRow >= 0 && newRow < rows && newColumn >= 0
                    && newColumn < columns && matrix[newRow][newColumn] < matrix[r][c])
                    {
                        indegree[r][c]++;
                    }
                }
            }
        }

        Queue<int[]> q = new Queue<int[]>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (indegree[r][c] == 0)
                {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }
        int lis = 0;

        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                int[] node = q.Dequeue();
                int r = node[0], c = node[1];
                foreach (var direction in directions)
                {
                    int newRow = r + direction[0], newColumn = c + direction[1];

                    if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && matrix[newRow][newColumn] > matrix[r][c])
                    {
                        if (--indegree[newRow][newColumn] == 0)
                        {
                            q.Enqueue(new int[] { newRow, newColumn });
                        }
                    }
                }
            }

            lis++;
        }
        return lis;
    }
}