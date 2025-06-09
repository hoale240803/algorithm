namespace algorithm.LinkedList;

public class FindTheDuplicateNumber
{
    // Sorting
    public int FindDuplicate(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                return nums[i];
            }
        }
        return -1;
    }

    // Hash set
    public int FindDuplicateNumber(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in nums)
        {
            if (seen.Contains(num))
            {
                return num;
            }
            seen.Add(num);
        }

        return -1;
    }

    // Bit manipulation

    public int FindDuplicate3(int[] nums)
    {
        int n = nums.Length;
        int res = 0;

        for (int b = 0; b < 32; b++)
        {
            int x = 0, y = 0;
            int mask = 1 << b;
            foreach (int num in nums)
            {
                if ((num & mask) != 0)
                {
                    x++;
                }
            }

            for (int num = 1; num < n; num++)
            {
                if ((num & mask) != 0)
                {
                    y++;
                }
            }
            if (x > y)
            {
                res |= mask;
            }
        }

        return res;
    }

    // fast and slow pointer

    public int FindDuplicate5(int[] nums)
    {
        int slow = 0, fast = 0;
        while (true)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast)
            {
                break;
            }
        }

        int slow2 = 0;
        while (true)
        {
            slow = nums[slow];
            slow2 = nums[slow2];
            if (slow == slow2)
            {
                return slow;
            }
        }

    }
}