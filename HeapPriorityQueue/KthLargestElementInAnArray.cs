namespace algorithm.HeapPriorityQueue;

public class KthSmallesIntegerInBST
{
    // sorting
    public int FindKthLargest(int[] nums, int k)
    {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }

    // min-help
    public int FindKthLargest2(int[] nums, int k)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }
        return minHeap.Peek();
    }
}