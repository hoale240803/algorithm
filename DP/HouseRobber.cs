namespace algorithm.DP;

public class HouseRobberClass
{
    // Recursion
    public int Rob(int[] nums)
    {
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i)
    {
        if (i >= nums.Length)
        {
            return 0;
        }

        return Math.Max(Dfs(nums, i + 1), nums[i] + Dfs(nums, i + 2));
    }

    public int Rob1(int[] nums)
    {
        int rob1 = 0, rob2 = 0;
        foreach (int num in nums)
        {
            int temp = Math.Max(num + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }

        return rob2;
    }
}