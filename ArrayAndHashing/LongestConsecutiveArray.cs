namespace Algorithm.ArrayAndHashing;

public class LongestConsecutiveArray
{
    public int LongestConsecutive(int[] nums) {
        // input: duplicate numbers are allowed, do not have to be consecutive with original array
        // exmaple: [100, 4, 200, 1, 3, 2]
        // output: 4
        // explanation: the longest consecutive sequence is [1, 2, 3, 4]

        // option 1: sort the array and then find the longest consecutive sequence
        // time complexity: O(n log n)
        // space complexity: O(1)


        // option 2: use a hashset to store the numbers
        // time complexity: O(n)
        // space complexity: O(n)

        HashSet<int> numSet = new HashSet<int>(nums);
        int longest = 0;

        foreach (int num in numSet) {
            if (!numSet.Contains(num - 1)) {
                int length = 1;
                while (numSet.Contains(num + length)) {
                    length++;
                }
                longest = Math.Max(longest, length);
            }
        }
        return longest;  
    }
}
