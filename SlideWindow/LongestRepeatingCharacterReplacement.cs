namespace Algorithm.SlideWindow;
public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        // You are given a string s consisting of only uppercase english characters and an integer k. 
        // You can choose up to k characters of the string and replace them with any other uppercase English character.
        // After performing at most k replacements, return the length of the longest substring 
        // which contains only one distinct character.
        // Example 1:
        // Input: s = "XYYX", k = 2
        // Output: 4
        // Explanation: Either replace the 'X's with 'Y's, or replace the 'Y's with 'X's.

        // Example 2:
        // Input: s = "AAABABB", k = 1
        // Output: 5

        // approach: apply sliding window technique and hashmap
        // use a hashmap to store the frequency of each character in the current window
        // use a variable to store the maximum length of the substring
        // use a variable to store the left pointer of the window
        // use a variable to store the right pointer of the window
        // use a variable to store the maximum frequency of the characters in the current window
        // use a variable to store the number of replacements
        // if the most frequent character in the current window plus the number of replacements 
        // is greater than the length of the window, we need to shrink the window from the left
        // time complexity: O(n)
        // space complexity: O(1)

        var hashmap = new Dictionary<char, int>();
        var left = 0;
        var maxLength = 0;
        var maxCount = 0; // max frequency of the characters in the current window

        for (int right = 0; right < s.Length; right++)
        {
            hashmap[s[right]] = hashmap.GetValueOrDefault(s[right], 0) + 1;
            maxCount = Math.Max(maxCount, hashmap[s[right]]);

            while (right - left + 1 - maxCount > k)
            {
                hashmap[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }


    // return longest after repeating characters
    public string CharacterReplacementString(string s, int k)
    {
        // You are given a string s consisting of only uppercase english characters and an integer k. 
        // You can choose up to k characters of the string and replace them with any other uppercase English character.
        // After performing at most k replacements, return the length of the longest substring 
        // which contains only one distinct character.
        // Example 1:
        // Input: s = "XYYX", k = 2
        // Output: "XXXX" or "YYYY"
        // Explanation: Either replace the 'X's with 'Y's, or replace the 'Y's with 'X's.

        // Example 2:
        // Input: s = "AAABABB", k = 1
        // Output: "AAAAA"

        return string.Empty;
    }
}