namespace Algorithm.SlideWindow;

public class MinimumWindowSubstring
{
    public string MinWindow(string s, string t)
    {
        // Given two strings s and t, return the shortest substring of s such that every character in t, including duplicates, is present in the substring. If such a substring does not exist, return an empty string "".
        // You may assume that the correct output is always unique.

        // Example 1:
        // Input: s = "OUZODYXAZV", t = "XYZ"
        // Output: "YXAZ"
        // Explanation: "YXAZ" is the shortest substring that includes "X", "Y", and "Z" from string t.

        // Example 2:
        // Input: s = "xyz", t = "xyz"
        // Output: "xyz"

        // Example 3:
        // Input: s = "x", t = "xy"
        // Output: ""

        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();

        foreach (char c in t)
        {
            if (countT.ContainsKey(c))
            {
                countT[c]++;
            }
            else
            {
                countT[c] = 1;
            }
        }

        int have = 0, need = countT.Count;
        int[] res = { -1, -1 };
        int resLen = int.MaxValue;
        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            char c = s[r];
            if (window.ContainsKey(c))
            {
                window[c]++;
            }
            else
            {
                window[c] = 1;
            }

            if (countT.ContainsKey(c) && window[c] == countT[c])
            {
                have++;
            }

            while (have == need)
            {

                if ((r - l + 1) < resLen)
                {
                    resLen = r - l + 1;
                    res[0] = l;
                    res[1] = r;
                }

                char leftChar = s[l];
                window[leftChar]--;
                if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar])
                {
                    have--;
                }
                l++;
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }
}