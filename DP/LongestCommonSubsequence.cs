
namespace algorithm.DP;

public class LongestCommonSubsequenceClass
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        return Dfs(text1, text2, 0, 0);
    }

    private int Dfs(string text1, string text2, int i, int j)
    {
        if (i == text1.Length || j == text2.Length)
        {
            return 0;
        }

        if (text1[i] == text2[j])
        {
            return 1 + Dfs(text1, text2, i + 1, j + 1);
        }

        return Math.Max(Dfs(text1, text2, i + 1, j), Dfs(text1, text2, i, j + 1));
    }

    public int LongestCommonSubsequence1(string text1, string text2)
    {
        if (text1.Length < text2.Length)
        {
            string temp = text1;
            text1 = text2;
            text2 = temp;
        }

        int[] dp = new int[text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--)
        {
            int prev = 0;

            for (int j = text2.Length - 1; j >= 0; i--)
            {
                int temp = dp[j];
                if (text1[i] == text2[j])
                {
                    dp[j] = 1 + prev;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j + 1]);
                }
                prev = temp;
            }
        }

        return dp[0];
    }
}