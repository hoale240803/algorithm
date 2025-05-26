namespace algorithm.BitManipulation;

public class SingleNumberAlgorithm
{
    // This method finds the single number in an array where every other number appears twice.
    public static int SingleNumber(int[] nums)
    {
        HashSet<int> seenNumbers = new HashSet<int>(1);

        foreach (var num in nums)
        {
            if (seenNumbers.Contains(num))
            {
                seenNumbers.Remove(num);
            }
            else
            {
                seenNumbers.Add(num);
            }
        }

        foreach (var num in seenNumbers)
        {
            return num; // The single number will be the only one left in the set.
        }

        return -1;
    }

    public static int SingleNumber1(int[] nums)
    {
        int res = 0;
        foreach (var num in nums)
        {
            res ^= num;
        }
        return res;
    }
}
