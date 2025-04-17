namespace Algorithm.TwoPointers;

public class TrappingRainWater
{
    public int Trap(int[] height)
    {

        // input: list array of integer numbers height, which has width equal 1
        // output: maximum area of water that can be traps between bars
        // Input: height = [0,2,0,3,1,0,1,3,2,1]

        // todo: apply two pointers and greedy algorithm
        // todo: calculate the area of the container
        // todo: return the maximum area

        int left = 0;
        int right = height.Length - 1;
        int maxLeft = 0;    
        int maxRight = 0;
        int area = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] > maxLeft){
                    
                    maxLeft = height[left];
                }
                else{

                    area += maxLeft - height[left];
                } 

                left++;
            }
            else
            {
                if (height[right] > maxRight) {
                    maxRight = height[right];
                }
                else {
                    area += maxRight - height[right];
                }
                
                right--;
            }
        }

        return area;
    }
}