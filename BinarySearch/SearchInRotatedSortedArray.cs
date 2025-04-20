namespace Algorithm.BinarySearch;
public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        // determine the pivot point
        // apply BinarySeach
        // if the target is greater than the pivot point, then the target is in the right half
        // if the target is less than the pivot point, then the target is in the left half
        // if the target is equal to the pivot point, then return the pivot point

        // example: [3,4,5,6,1,2]
        // left = 0, right = 5
        // mid = 2
        // nums[mid] = 5
        // nums[right] = 2
        // since nums[mid] > nums[right], the pivot point is in the right half
        // so we move left to mid + 1


        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] >= nums[right])
            {
                if (nums[left] <= target && target <= nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else if (nums[mid] <= nums[right])
            {
                if (nums[mid] <= target && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}