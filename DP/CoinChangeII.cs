namespace algorithm.DP;

public class CoinChangeII
{
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);
        return Dfs(coins, 0, amount);
    }

    private int Dfs(int[] coins, int i, int a)
    {
        if (a == 0)
        {
            return 1;
        }
        if (i >= coins.Length) return 0;

        int res = 0;
        if (a >= coins[i])
        {
            res = Dfs(coins, i + 1, a);
            res += Dfs(coins, i, a - coins[i]);
        }

        return res;
    }

    // Dynamic Programming (optimal)
    public int Change2(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        for (int i = coins.Length - 1; i >= 0; i--)
        {
            for (int a = 1; a <= amount; a++)
            {
                dp[a] += (coins[i] <= a ? dp[a - coins[i]] : 0);
            }
        }

        return dp[amount];
    }
}