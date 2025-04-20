namespace Algorithm.BinarySearch;
public class MinimumInRotatedSortedArray
{
    public int FindMin(int[] nums)
    {

        //You are given an array of length n which was originally sorted in ascending order. It has now been rotated between 1 and n times. For example, the array nums = [1,2,3,4,5,6] might become:

        // [3,4,5,6,1,2] if it was rotated 4 times.
        // [1,2,3,4,5,6] if it was rotated 6 times.
        // Notice that rotating the array 4 times moves the last four elements of the array to the beginning. Rotating the array 6 times produces the original array.

        // Assuming all elements in the rotated sorted array nums are unique, return the minimum element of this array.

        // A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?

        // Example 1:

        // Input: nums = [3,4,5,6,1,2]

        // Output: 1


        // apply BinarySeach
        // find the pivot point
        // the pivot point is the point where the array is rotated
        // the pivot point is the minimum element in the array


        // example: [3,4,5,6,1,2]
        // left = 0, right = 5
        // mid = 2
        // nums[mid] = 5
        // nums[right] = 2
        // since nums[mid] > nums[right], the pivot point is in the right half
        // so we move left to mid + 1

        // example: [6,1,2,3,4,5]
        // left = 0, right = 5
        // mid = 2
        // nums[mid] = 2
        // nums[right] = 5
        // since nums[mid] < nums[right], the pivot point is in the left half
        // so we move right to mid

        // example: [1,2,3,4,5,6]
        // left = 0, right = 5
        // mid = 2
        // nums[mid] = 3
        // nums[right] = 6
        // since nums[mid] < nums[right], the pivot point is in the left half
        // so we move right to mid


        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left];
    }
}