
namespace algorithm.DP;

public class WorkBreakClass
{
    public bool WordBreak(string s, List<string> wordDict)
    {
        return Dfs(s, wordDict, 0);
    }

    private bool Dfs(string s, List<string> wordDict, int i)
    {
        if (i == s.Length) return true;

        foreach (string w in wordDict)
        {
            if (i + w.Length <= s.Length && s.Substring(i, w.Length) == w)
            {
                if (Dfs(s, wordDict, i + w.Length))
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Dynamic Programming - Bottom-up
    public bool WordBreak1(string s, List<string> wordDict)
    {
        bool[] dp = new bool[s.Length + 1];
        dp[s.Length] = true;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            foreach (string w in wordDict)
            {
                if ((i + w.Length) <= s.Length && s.Substring(i, w.Length) == w)
                {
                    dp[i] = dp[i + w.Length];
                }
                if (dp[i])
                {
                    break;
                }
            }
        }

        return dp[0];
    }
}