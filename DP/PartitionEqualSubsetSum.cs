

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
}