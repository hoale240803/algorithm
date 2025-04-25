namespace Algorithm.SlideWindow;
public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        // Given a string s, find the length of the longest substring without duplicate characters.
        // A substring is a contiguous sequence of characters within a string.
        // Example 1:
        // Input: s = "zxyzxyz"
        // Output: 3

        // Explanation: The string "xyz" is the longest without duplicate characters.
        // Example 2:
        // Input: s = "xxxx"
        // Output: 1

        // options 1: using hashmap brute force
        // use a hashmap to store the characters and their indices
        // if the character is already in the hashmap, move the left pointer to the next character
        // if the character is not in the hashmap, add it to the hashmap
        // the length of the longest substring is the difference between the right pointer and the left pointer
        // the hashmap is used to store the characters and their indices
        // the hashmap is used to check if the character is already in the substring
        // time complexity: O(n)
        // space complexity: O(min(n, m))
        // where n is the length of the string and m is the size of the character set
        // for this problem, m is 26 (for the english alphabet)
        // so the space complexity is O(n)

        var hashmap = new Dictionary<char, int>(); // key: character, value: index
        var left = 0;
        var maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (hashmap.ContainsKey(s[right]))
            {
                left = Math.Max(left, hashmap[s[right]] + 1);
            }
            hashmap[s[right]] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}