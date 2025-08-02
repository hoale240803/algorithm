namespace algorithm.DP;

public class HouseRobberIIClass
{
    // 1. Recursion
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        return Math.Max(Dfs(0, true, nums), Dfs(1, false, nums));
    }

    private int Dfs(int i, bool flag, int[] nums)
    {
        if (i >= nums.Length || (flag && i == nums.Length - 1))
        {
            return 0;
        }

        return Math.Max(Dfs(i + 1, flag, nums),
                        nums[i] + Dfs(i + 2, flag || i == 0, nums));
    }

    // Dynamic Programing - Space Optimized

    public int Rob1(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(Helper(nums[1..]), Helper(nums[..^1]));

    }

    private int Helper(int[] nums)
    {
        int rob1 = 0, rob2 = 0;
        foreach (int num in nums)
        {
            int newRob = Math.Max(rob1 + num, rob2);
            rob1 = rob2;
            rob2 = newRob;
        }

        return rob2;
    }
}