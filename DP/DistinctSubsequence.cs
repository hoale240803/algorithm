
namespace algorithm.DP;

public class DistinctSubsequence
{
    public int NumDistinct(string s, string t)
    {
        if (t.Length > s.Length)
        {
            return 0;
        }
        return Dfs(s, t, 0, 0);
    }

    private int Dfs(string s, string t, int i, int j)
    {
        if (j == t.Length)
        {
            return 1;
        }

        if (i == s.Length)
        {
            return 0;
        }

        int res = Dfs(s, t, i + 1, j);
        if (s[i] == t[j])
        {
            res += Dfs(s, t, i + 1, j + 1);
        }

        return res;
    }

    public int NumDistinct1(string s, string t)
    {
        int m = s.Length, n = t.Length;
        int[] dp = new int[n + 1];

        dp[n] = 1;
        for (int i = m - 1; i >= 0; i--)
        {
            int prev = 1;
            for (int j = n - 1; j >= 0; j--)
            {
                int res = dp[j];
                if (s[i] == t[j])
                {
                    res += prev;
                }

                prev = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
}