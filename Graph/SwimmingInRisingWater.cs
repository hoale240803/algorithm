namespace algorithm.Graph;

public class SwimmingInRisingWater
{
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            visit[i] = new bool[n];
        }

        return Dfs(grid, visit, 0, 0, 0);
    }

    private int Dfs(int[][] grid, bool[][] visit, int r, int c, int t)
    {
        int n = grid.Length;
        if (r < 0 || c < 0 || r >= n || c >= n || visit[r][c])
        {
            return 1000000;
        }

        if (r == n - 1 && c == n - 1)
        {
            return Math.Max(t, grid[r][c]);
        }

        visit[r][c] = true;
        t = Math.Max(t, grid[r][c]);
        int res = Math.Min(
            Math.Min(Dfs(grid, visit, r + 1, c, t), Dfs(grid, visit, r - 1, c, t)),
            Math.Min(Dfs(grid, visit, r, c + 1, t), Dfs(grid, visit, r, c - 1, t)));
        visit[r][c] = false;
        return res;
    }


    // Dijkstra's algorithm

    public int SimInWater1(int[][] grid)
    {
        int N = grid.Length;
        var visit = new HashSet<(int, int)>();
        var minHeap = new PriorityQueue<(int t, int r, int c), int>();

        int[][] directions = {
            new int[]{0, 1}, new int [] {0,-1},
            new int[]{1, 0}, new int[]{-1, 0}
        };

        minHeap.Enqueue((grid[0][0], 0, 0), grid[0][0]);
        visit.Add((0, 0));

        while (minHeap.Count > 0)
        {
            var curr = minHeap.Dequeue();
            int t = curr.t, r = curr.r, c = curr.c;

            if (r == N - 1 && c == N - 1)
            {
                return t;
            }
            foreach (var dir in directions)
            {

                int neiR = r + dir[0], neiC = c + dir[1];
                if (neiR < 0 || neiC < 0 || neiR >= N
                || neiC >= N || visit.Contains((neiR, neiC)))
                {
                    continue;
                }
                visit.Add((neiR, neiC));
                minHeap.Enqueue((Math.Max(t, grid[neiR][neiC]), neiR, neiC),
                Math.Max(t, grid[neiR][neiC]));
            }
        }

        return N * N;
    }
}