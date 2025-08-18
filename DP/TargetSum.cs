
namespace algorithm.DP;

public class TargetSumClass
{
    //
    public int FindTargetSumWays(int[] nums, int target)
    {
        return BackTrack(0, 0, nums, target);
    }

    private int BackTrack(int i, int total, int[] nums, int target)
    {
        if (i == nums.Length)
        {
            return total == target ? 1 : 0;
        }

        return BackTrack(i + 1, total + nums[i], nums, target) + BackTrack(i + 1, total - nums[i], nums, target);
    }

    // 4. Dynamic programming (space optimized)
    public int FindTargetSumWays1(int[] nums, int target)
    {
        Dictionary<int, int> dp = new Dictionary<int, int>();
        dp[0] = 1;

        foreach (int num in nums)
        {
            Dictionary<int, int> nextDp = new Dictionary<int, int>();

            foreach (var entry in dp)
            {
                int total = entry.Key;
                int count = entry.Value;

                if (!nextDp.ContainsKey(total + num))
                {
                    nextDp[total + num] = 0;
                }
                nextDp[total + num] += count;

                if (!nextDp.ContainsKey(total - num))
                {
                    nextDp[total - num] = 0;
                }

                nextDp[total - num] += count;
            }
            dp = nextDp;
        }

        return dp.ContainsKey(target) ? dp[target] : 0;
    }
}