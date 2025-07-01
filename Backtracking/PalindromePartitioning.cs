
namespace algorithm.Backtrackingl;

public class PalindromePartitioning
{
    // 1. Backtracking
    private List<List<string>> res = new List<List<string>>();
    private List<string> part = new List<string>();
    public List<List<string>> Partition(string s)
    {
        dfs(0, 0, s);
        return res;
    }

    private void dfs(int j, int i, string s)
    {
        if (i >= s.Length)
        {
            if (i == j)
            {
                res.Add(new List<string>(part));
            }
            return;
        }

        if (isPali(s, j, i))
        {
            part.Add(s.Substring(j, i - j + 1));
            dfs(i + 1, i + 1, s);
            part.RemoveAt(part.Count - 1);
        }

        dfs(j, i + 1, s);
    }

    private bool isPali(string s, int l, int r)
    {
        while (l < r)
        {
            if (s[l] != s[r])
            {
                return false;
            }

            l++;
            r--;
        }

        return true;
    }


    // 2. Dynamic Programming
    public List<List<string>> PartitionDP(string s)
    {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 0; l <= n; l++)
        {
            for (int i = 0; i < n - l; i++)
            {
                dp[i, i + l - 1] = (s[i] == s[i + l - 1]
                    && (i + 1 > (i + l - 2)))
                    || dp[i + 1, i + l - 2];

            }
        }

        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        Dfs(0, s, part, res, dp);
        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res, bool[,] dp)
    {
        if (i >= s.Length)
        {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++)
        {
            if (dp[i, j])
            {
                part.Add(s.Substring(i, j - i + 1));

                Dfs(j + 1, s, part, res, dp);
                part.RemoveAt(part.Count - 1);
            }
        }
    }
}