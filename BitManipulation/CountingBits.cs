namespace algorithm.BitManipulation;

public class CountingBits
{
    public int[] CountBits(int n)
    {
        int[] res = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            int num = i;
            while (num != 0)
            {
                res[i]++;
                num &= (num - 1);
            }
        }
        return res;
    }

    // optimal
    public int[] CountBits1(int n)
    {
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i >> 1] + (i & 1);
        }

        return dp;
    }
}