
namespace algorithm.Graph;

public class PacificAtlanticWater
{
    // Depth First search
    private int[][] directions = new int[][]{
        new int[]{1,0},new int[]{-1,0},
        new int[]{0,1}, new int[]{0,-1}
    };

    public List<List<int>> PacificAtlantic(int[][] heights)
    {
        int rows = heights.Length, cols = heights[0].Length;
        bool[,] pac = new bool[rows, cols];
        bool[,] atl = new bool[rows, cols];

        for (int c = 0; c < cols; c++)
        {
            Dfs(0, c, pac, heights);
            Dfs(rows - 1, c, atl, heights);
        }

        for (int r = 0; r < rows; r++)
        {
            Dfs(r, 0, pac, heights);
            Dfs(r, cols - 1, atl, heights);
        }

        List<List<int>> res = new List<List<int>>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (pac[r, c] && atl[r, c])
                {
                    res.Add(new List<int> { r, c });
                }
            }
        }

        return res;
    }

    private void Dfs(int r, int c, bool[,] ocean, int[][] heights)
    {
        ocean[r, c] = true;
        foreach (var dir in directions)
        {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < heights.Length && nc >= 0 && nc < heights[0].Length && !ocean[nr, nc] && heights[nr][nc] >= heights[r][c])
            {
                Dfs(nr, nc, ocean, heights);
            }
        }
    }
}