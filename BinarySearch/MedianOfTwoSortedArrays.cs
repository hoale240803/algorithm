namespace Algorithm.BinarySearch;
public class MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // You are given two integer arrays nums1 and nums2 of size m and n respectively, where each is sorted in ascending order. Return the median value among all elements of the two arrays.

        // Your solution must run in 
        // O(log(m+n)) time.

        // Example 1:

        // Input: nums1 = [1,2], nums2 = [3]

        // Output: 2.0
        // Explanation: Among [1, 2, 3] the median is 2.

        // Example 2:

        // Input: nums1 = [1,3], nums2 = [2,4]

        // Output: 2.5
        // Explanation: Among [1, 2, 3, 4] the median is (2 + 3) / 2 = 2.5.

        // apply binary search to find the median
        // conquer the problem by dividing the problem into smaller subproblems
        // divide the problem into smaller subproblems
        // solve the smaller subproblems
        // combine the solutions of the smaller subproblems to solve the original problem  

        // note: empty array return 0
        // keep length of the array A greater than B. we apply binary search on the smaller array.
        // ensure the median of left half is less than or equal to the median of right half.
        // if the median of left half is greater than the median of right half, we move the right pointer to the left of the median of left half.
        // if the median of left half is less than the median of right half, we move the left pointer to the right of the median of right half.
        // we continue this process until we find the median.

        // Handle empty arrays
        if (nums1 == null || nums2 == null)
        {
            return 0;
        }

        // If both arrays are empty
        if (nums1.Length == 0 && nums2.Length == 0)
        {
            return 0;
        }

        // If one array is empty, return median of the other
        if (nums1.Length == 0)
        {
            return GetMedian(nums2);
        }
        if (nums2.Length == 0)
        {
            return GetMedian(nums1);
        }

        // ensure nums1 is the smaller array
        if (nums1.Length > nums2.Length)
        {
            var temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        var x = nums1.Length;
        var y = nums2.Length;

        var low = 0;
        var high = x;

        while (low <= high)
        {
            // example:
            // nums1 = [1, 2], nums2 = [3, 4]
            // low = 0, high = 2
            // partitionX = (0 + 2) / 2 = 1
            // partitionY = (2 + 2 + 1) / 2 - 1 = 2
            // maxLeftX = 1, minRightX = 2, maxLeftY = 3, minRightY = 4
            // maxLeftX <= minRightY and maxLeftY <= minRightX, false
            // low = partitionX + 1 = 2


            var partitionX = (low + high) / 2;
            var partitionY = (x + y + 1) / 2 - partitionX;

            var maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            var minRightX = partitionX == x ? int.MaxValue : nums1[partitionX];

            var maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            var minRightY = partitionY == y ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                if ((x + y) % 2 == 0)
                {
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                }
                else
                {
                    return Math.Max(maxLeftX, maxLeftY);
                }
            }
            else if (maxLeftX > minRightY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }
        }

        // This should never be reached for valid inputs
        return 0;
    }

    private double GetMedian(int[] nums)
    {
        int n = nums.Length;
        if (n % 2 == 0)
        {
            return (nums[n / 2 - 1] + nums[n / 2]) / 2.0;
        }
        else
        {
            return nums[n / 2];
        }
    }
}