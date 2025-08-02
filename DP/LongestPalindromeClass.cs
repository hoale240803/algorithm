using System.Security.Cryptography.X509Certificates;

namespace algorithm.DP;

public class LongestPalindromeClass
{
    //1 brute force

    public string LongestPalindrome(string s)
    {
        string res = "";
        int resLen = 0;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                int l = i, r = j;
                while (l < r && s[l] == s[r])
                {
                    l++;
                    r--;
                }

                if (l >= r && resLen < (j - i + 1))
                {
                    res = s.Substring(i, j - i + 1);
                    resLen = j - i + 1;
                }
            }
        }

        return res;
    }

    // Mancher's algorithms

    public int[] Manacher(string s)
    {
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";
        int n = t.Length;
        int[] p = new int[n];
        int l = 0, r = 0;

        for (int i = 0; i < n; i++)
        {
            p[i] = (i < r) ? Math.Min(r - i, p[l + (r - i)]) : 0;

            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0
            && t[i + p[i] + 1] == t[i - p[i] - 1])
            {
                p[i]++;
            }
            if (i + p[i] > r)
            {
                l = i - p[i];
                r = i + p[i];
            }

        }
        return p;
    }

    public string LongestPalindrome2(string s)
    {
        int[] p = Manacher(s);
        int resLen = 0, center_idx = 0;

        for (int i = 0; i < p.Length; i++)
        {
            if (p[i] > resLen)
            {
                resLen = p[i];
                center_idx = i;
            }
        }

        int resIdx = (center_idx - resLen) / 2;
        return s.Substring(resIdx, resLen);
    }
}