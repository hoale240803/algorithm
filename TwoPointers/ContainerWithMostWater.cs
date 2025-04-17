namespace Algorithm.TwoPointers;


public class ContainerWithMostWaterTwoPointers
{
    public int MaxArea(int[] heights)
    {
        // input: an array of integers
        // output: the maximum area of water that can be stored in a container
        // constraints: 
        // - the array has at least two elements
        // - the array can be empty
        // - the array can have negative values
        // - the array can have duplicate values

        // todo: apply two pointers and greedy algorithm
        // todo: calculate the area of the container
        // todo: return the maximum area

        int left = 0;
        int right = heights.Length - 1;
        int maxArea = 0;
        while (left < right)
        {
            var width = right - left;
            var height = Math.Min(heights[left], heights[right]); 
            var area = width * height;

            maxArea = Math.Max(maxArea, area);
            
            if (heights[left] < heights[right])
            {
                left++;
            }
            else {
                right--;
            }
        }

        return maxArea;
    }
}