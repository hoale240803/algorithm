namespace Algorithm.SlideWindow;
public class PermutationInString
{
    public bool CheckInclusion(string s1, string s2)
    {
        // You are given two strings s1 and s2.
        // Return true if s2 contains a permutation of s1, or false otherwise. 
        // That means if a permutation of s1 exists as a substring of s2, then return true.
        // Both strings only contain lowercase letters.

        // Example 1:
        // Input: s1 = "abc", s2 = "lecabee"
        // Output: true
        // Explanation: The substring "cab" is a permutation of "abc" and is present in "lecabee".

        // Example 2:
        // Input: s1 = "abc", s2 = "lecaabee"
        // Output: false

        // time complexity: O(n)
        // space complexity: O(1)

        // approach: sliding window technique and hashmap with 26 characters
        // use a hashmap to store the frequency of each character in s1
        // use a hashmap to store the frequency of each character in s2
        // add right pointer to s2 and remove left pointer from s2
        // remove left pointer from s1Count and add right pointer to s1Count
        // compare the frequency of each character in s2 with the frequency of each character in s1
        // if they are the same, return true
        // otherwise, return false

        if (s1.Length > s2.Length)
        {
            return false;
        }

        var s1Count = new int[26];
        var s2Count = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        var matches = 0;
        for (int i = 0; i < 26; i++)
        {
            if (s1Count[i] == s2Count[i])
            {
                matches++;
            }
        }

        var l = 0;
        for (int r = s1.Length; r < s2.Length; r++)
        {

            if (matches == 26)
            {
                return true;
            }

            int index = s2[r] - 'a';
            s2Count[index]++;
            if (s1Count[index] == s2Count[index])
            {
                matches++;
            }
            else if (s1Count[index] + 1 == s2Count[index])
            {
                matches--;
            }

            index = s2[l] - 'a';
            s2Count[index]--;
            if (s1Count[index] == s2Count[index])
            {
                matches++;
            }
            else if (s1Count[index] - 1 == s2Count[index])
            {
                matches--;
            }

            l++;
        }

        return matches == 26;
    }
}