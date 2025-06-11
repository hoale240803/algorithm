namespace algorithm.ArrayAndHashing;

public class ContainsDuplicate
{
    public bool hasDuplicate(int[] nums)
    {
        HashSet<int> seenNumbers = new HashSet<int>();
        foreach (int num in nums)
        {
            if (seenNumbers.Contains(num))
            {
                return true; // Duplicate found
            }
            seenNumbers.Add(num); // Add the number to the set
        }

        return false;
    }
}