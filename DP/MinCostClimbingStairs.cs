namespace algorithm.DP;

public class MinCostClimbingStair

{   // Recursion
    public int MinCostClimbingStairs(int[] cost)
    {
        return Math.Min(Dfs(cost, 0), Dfs(cost, 1));
    }

    private int Dfs(int[] cost, int i)
    {
        if (i >= cost.Length)
        {
            return 0;
        }

        return cost[i] + Math.Min(Dfs(cost, i + 1), Dfs(cost, i + 2));
    }

    // Dynamic Programing - Space Optimized

    public int MinCostClimbingStairs2(int[] cost)
    {
        for (int i = cost.Length - 3; i >= 0; i--)
        {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }
        return Math.Min(cost[0], cost[1]);
    }
}