namespace Algorithm.ArrayAndHashing;

public class TwoIntegerSumArray
{
    public int[] TwoSum(int[] numbers, int target)
    {

        // input: an array of integer numbers sorted increased
        // Return the indices (1-indexed) of two numbers, [index1, index2], 
        // Such that they add up to a given target number target
        // index1 < index2.

        // todo: Using array index and array value. Apply greedy algorithm, take advantage of the sorted array
        // todo: the target subtract to the largest number in the array
        // todo: check if the result is in the array
        // todo: if it is, return the indices
        // todo: if it is not, move the pointer

        for (int i = 0; i < numbers.Length; i++)
        {
            int complement = target - numbers[i];
            var index = Array.IndexOf(numbers, complement);
            if (index != -1)
            {
                return new int[] { i + 1, index + 1 };
            }
        }

        return new int[] { };
    }
}