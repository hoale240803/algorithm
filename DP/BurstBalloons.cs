namespace algorithm.DP;

public class BurstBalloon
{
    public int MaxCoins(int[] nums)
    {
        List<int> newNums = new List<int>();
        newNums.AddRange(nums);
        newNums.Add(1);

        return Dfs(newNums);
    }

    public int Dfs(List<int> nums)
    {
        if (nums.Count == 2) return 0;

        int maxCoins = 0;

        for (int i = 0; i < nums.Count; i++)
        {
            int coins = nums[i - 1] * nums[i] * nums[i + 1];
            List<int> newNums = new(nums);
            newNums.RemoveAt(i);
            coins += Dfs(newNums);
            maxCoins = Math.Max(maxCoins, coins);
        }

        return maxCoins;
    }


    public int MaxCoins2(int[] nums)
    {
        int n = nums.Length;
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++)
        {
            newNums[i + 1] = nums[i];
        }

        int[,] dp = new int[n + 2, n + 2];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                dp[i, j] = -1;
            }
        }

        return Dfs2(newNums, 1, newNums.Length - 2, dp);
    }

    // DP top-down
    public int Dfs2(int[] nums, int l, int r, int[,] dp)
    {
        if (l > r) return 0;

        if (dp[l, r] != -1) return dp[l, r];

        dp[l, r] = 0;
        for (int i = 0; i <= r; i++)
        {
            int coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += Dfs2(nums, l, i - 1, dp) + Dfs2(nums, i + 1, r, dp);
            dp[l, r] = Math.Max(dp[l, r], coins);
        }

        return dp[l, r];
    }

    // DP bottom-up

    public int MaxCoins3(int[] nums)
    {
        int n = nums.Length;
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++)
        {
            newNums[i + 1] = nums[i];
        }

        int[,] dp = new int[n + 2, n + 2];

        for (int l = n; l >= 1; l--)
        {
            for (int r = l; r <= n; r++)
            {
                for (int i = l; i <= r; i++)
                {
                    int coins = newNums[l - 1] * newNums[i] * newNums[r + 1];
                    coins += dp[l, i - 1] + dp[i + 1, r];
                    dp[l, r] = Math.Max(dp[l, r], coins);
                }
            }
        }
        return dp[1, n];
    }
}
