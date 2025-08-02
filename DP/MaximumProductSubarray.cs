namespace algorithm.DP;

public class MaximumProductSubarray
{
    // Brute force
    public int MaxProduct(int[] nums)
    {
        int res = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            int cur = nums[i];
            res = Math.Max(res, cur);

            for (int j = i + 1; j < nums.Length; j++)
            {
                cur *= nums[i];
                res = Math.Max(res, cur);
            }
        }

        return res;
    }

    // prefix suffix

    public int MaxProduct2(int[] nums)
    {
        int n = nums.Length;
        int res = nums[0];
        int prefix = 0, suffix = 0;

        for (int i = 0; i < n; i++)
        {
            prefix = nums[i] * (prefix == 0 ? 1 : prefix);
            suffix = nums[n - 1 - i] * (suffix == 0 ? 1 : suffix);
            res = Math.Max(res, Math.Max(prefix, suffix));
        }

        return res;
    }
}