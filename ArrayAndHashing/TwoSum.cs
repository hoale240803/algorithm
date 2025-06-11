namespace algorithm.ArrayAndHashing;

public class TwoSumClass
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int[] res = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(nums[i], out int value))
            {
                res[0] = value;
                res[1] = i;
                return res;
            }
            dict.Add(target - nums[i], i);
        }

        return res;
    }
}