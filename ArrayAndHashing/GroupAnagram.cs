namespace algorithm.ArrayAndHashing;

public class GroupAnagram
{
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var res = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            int[] count = new int[26];
            for (int i = 0; i < str.ToCharArray().Length; i++)
            {
                count[str[i] - 'a']++;
            }
            var key = string.Join(",", count);

            if (!res.ContainsKey(key))
            {
                res.Add(key, new List<string> { str });
            }
            else
            {
                res[key].Add(str);
            }
        }

        return res.Values.ToList();
    }
}