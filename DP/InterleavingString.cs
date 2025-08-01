

namespace algorithm.DP;

public class InterleavingString
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        return dfs(0, 0, 0, s1, s2, s3);
    }

    private bool dfs(int i, int j, int k, string s1, string s2, string s3)
    {
        if (k == s3.Length)
        {
            return (i == s1.Length) && (j == s2.Length);
        }

        if (i < s1.Length && s1[i] == s3[k])
        {
            if (dfs(i + 1, j, k + 1, s1, s2, s3))
            {
                return true;
            }
        }

        if (j < s2.Length && s2[j] == s3[k])
        {
            if (dfs(i, j + 1, k + 1, s1, s2, s3))
            {
                return true;
            }
        }

        return false;
    }

    // Dynamic Programming - Optimal

    public bool IsInterleave2(string s1, string s2, string s3)
    {
        int m = s1.Length, n = s2.Length;
        if (m + n != s3.Length) return false;

        if (n < m)
        {
            var temp = s1;
            s1 = s2;
            s2 = temp;
            int tempLen = m;
            m = n;
            n = tempLen;
        }

        bool[] dp = new bool[n + 1];
        dp[n] = true;
        for (int i = m; i >= 0; i--)
        {
            bool nextDp = true;
            for (int j = n - 1; j >= 0; j--)
            {
                bool res = false;
                if (i < m && s1[i] == s3[i + j] && dp[j])
                {
                    res = true;
                }
                if (j < n && s2[j] == s3[i + j] && nextDp)
                {
                    res = true;
                }
                dp[j] = res;
                nextDp = dp[j];
            }
        }
        return dp[0];
    }
}