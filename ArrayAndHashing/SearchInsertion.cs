namespace algorithm.ArrayAndHashing;

public class SearchInsertion
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length, middle = 0;

        while (left <= right)
        {
            middle = (right + left) / 2;
            if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else if (nums[middle] > target)
            {
                right = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return left;
    }
}