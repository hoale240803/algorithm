namespace algorithm.ArrayAndHashing;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();

        foreach (var c in s.ToCharArray())
        {
            if (!dic.TryGetValue(c, out int value))
            {
                dic.Add(c, 1);
            }
            else
            {
                dic[c] = value + 1; // Increment the count for the character
            }
        }

        foreach (var c in t.ToCharArray())
        {
            if (dic.TryGetValue(c, out int value))
            {
                if (dic[c] > 1)
                {
                    dic[c] = value - 1;
                }
                else
                {
                    dic.Remove(c);
                }
            }
        }

        foreach (var item in dic)
        {
            // If any character count is greater than 1, it's not an anagram
            if (item.Value > 0)
            {
                return false; // Not an anagram
            }
        }

        return t.Length == s.Length; // If all counts are zero, it's an anagram
    }

    public bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] count = new int[256];

        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        foreach (int c in count)
        {
            if (c > 0)
            {
                return false;
            }
        }

        return true;
    }
}