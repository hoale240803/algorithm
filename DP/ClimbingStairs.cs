namespace algorithm.DP;

public class ClimbingStairs
{
    public int ClimbStairs(int n)
    {
        return Dfs(n, 0);
    }

    public int Dfs(int n, int i)
    {
        if (i >= n) return i == n ? 1 : 0;

        return Dfs(n, i + 1) + Dfs(n, i + 2);
    }

    // Dynamic Programming - Space optimized

    public int ClimbStairs2(int n)
    {
        int one = 1, two = 1;

        for (int i = 0; i < n - 1; i++)
        {
            int temp = one;
            one = one + two;
            two = temp;
        }

        return one;
    }
}