using System.Text.RegularExpressions;

namespace algorithm.Greedy;

public class MaximumSubarray
{

    // brute force
    public int MaxSubArray(int[] nums)
    {
        int n = nums.Length, res = nums[0];

        for (int i = 0; i < n; i++)
        {
            int cur = 0;
            for (int j = i; j < n; j++)
            {
                cur += nums[j];
                res = Math.Max(res, cur);
            }
        }

        return res;
    }

    // dynamic programming space optimized
    public int MaxSubArray1(int[] nums)
    {
        int[] dp = (int[])nums.Clone();

        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
        }

        int maxSum = dp[0];
        foreach (var sum in dp)
        {
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }

    // Kadane's algorithm

    public int MaxSubArray2(int[] nums)
    {
        int maxSub = nums[0], curSum = 0;

        foreach (var num in nums)
        {
            if (curSum < 0)
            {
                curSum = 0;
            }
            curSum += num;
            maxSub = Math.Max(maxSub, curSum);
        }

        return maxSub;
    }
}