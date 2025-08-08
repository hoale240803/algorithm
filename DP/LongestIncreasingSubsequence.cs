namespace algorithm.DP;

public class LongestIncreasingSubsequence
{
    // Recursion
    public int LengthOfLIS(int[] nums)
    {
        return Dfs(nums, 0, -1);
    }

    private int Dfs(int[] nums, int i, int j)
    {

        if (i == nums.Length)
        {
            return 0;
        }

        int lis = Dfs(nums, i + 1, j);

        if (j == -1 || nums[j] < nums[i])
        {
            lis = Math.Max(lis, 1 + Dfs(nums, i + 1, i));
        }

        return lis;
    }

    // Dynamic programming + binary search

    public int LengthOfLIS2(int[] nums)
    {
        List<int> dp = new List<int>();
        dp.Add(nums[0]);

        int lis = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (dp[dp.Count - 1] < nums[i])
            {
                dp.Add(nums[i]);
                lis++;
                continue;
            }

            int index = dp.BinarySearch(nums[i]);
            if (index < 0) index = ~index;
            dp[index] = nums[i];
        }

        return lis;
    }
}