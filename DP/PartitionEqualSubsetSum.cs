


namespace algorithm.DP;

public class PartitionEqualSubsetSum
{
    // 1. Recursion
    public bool CanPartition(int[] nums)
    {
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0)
        {
            return false;
        }

        return Dfs(nums, 0, sum / 2);
    }

    private bool Dfs(int[] nums, int i, int target)
    {
        if (i == nums.Length)
        {
            return target == 0;
        }

        if (target < 0)
        {
            return false;
        }

        return Dfs(nums, i + 1, target) || Dfs(nums, i + 1, target - nums[i]);
    }

    // Dynamic Programming (Top-Down)

    private bool?[,] memo;

    public bool CanPartition2(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        if (sum % 2 != 0)
        {
            return false;
        }
        memo = new bool?[nums.Length + 1, sum / 2 + 1];

        return Dfs1(nums, 0, sum / 2);
    }


    private bool Dfs1(int[] nums, int i, int target)
    {
        if (target == 0)
        {
            return true;
        }
        if (i == nums.Length || target < 0)
        {
            return false;
        }
        if (memo[i, target] != null)
        {
            return memo[i, target] == true;
        }

        bool result = Dfs1(nums, i + 1, target) || Dfs1(nums, i + 1, target - nums[i]);

        memo[i, target] = result;

        return result;
    }

    // 3. Dynamic Programming (Optimal)

    public bool CanPartition3(int[] nums)
    {
        if (Sum(nums) % 2 != 0)
        {
            return false;
        }
        int target = Sum(nums) / 2;
        bool[] dp = new bool[target + 1];

        dp[0] = true;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = target; j >= nums[i]; j--)
            {
                dp[j] = dp[j] || dp[j - nums[i]];
            }
        }

        return dp[target];
    }

    private int Sum(int[] nums)
    {
        int total = 0;
        foreach (var num in nums)
        {
            total += num;
        }

        return total;
    }
}